using Microsoft.AspNetCore.Http;
using MySocialMedia.Common.DBTables.MessageDTOs;
using MySocialMedia.Logic.Services;
using System.Collections.Concurrent;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;

namespace MySocialMedia.API.Middlwares
{
    public class WebSocketMiddlewareInjector
    {
        private readonly RequestDelegate _next;

        public WebSocketMiddlewareInjector(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IUserService userService , IMessageService messageService)
        {
            if (context.Request.Path == "/ws")
            {
                var middleware = new MyWebSocketMiddleware(_next, userService , messageService);
                await middleware.InvokeAsync(context);
            }
            else
            {
                await _next(context);
            }
        }
    }
    public class MyWebSocketMiddleware
    {
        private readonly RequestDelegate _next;
        private IUserService _userService;
        private IMessageService _messageService;
        private static ConcurrentDictionary<string, WebSocket> _userSockets = new ConcurrentDictionary<string, WebSocket>();

        public MyWebSocketMiddleware(RequestDelegate p_next , IUserService userService , IMessageService messageService)
        {
            _messageService = messageService;
            _next = p_next;
            _userService = userService;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path == "/ws")
            {
                Console.WriteLine($"Incoming request path: {context.Request.Path}");

                if (!context.WebSockets.IsWebSocketRequest ||
                    !context.Request.Headers.TryGetValue("Sec-WebSocket-Protocol", out var token) ||
                    !await ValidateToken(token))
                {
                    context.Response.StatusCode = 400;
                    return;
                }

                var webSocket = await context.WebSockets.AcceptWebSocketAsync();
                _userSockets[token] = webSocket;

                //_sockets.Add(webSocket);
                await HandleWebSocketConnection(webSocket,token);
            }
            else
            {
                Console.WriteLine($"Incoming request path: {context.Request.Path}");
                Console.WriteLine("Processing regular request...");
                await _next(context);
            }

        }
        private async Task<bool> ValidateToken(string token)
        {
            var exists = await _userService.UserExists(token);
            Console.WriteLine($"Token {token} , exists : {exists}");
            return exists;
        }
        private async Task HandleWebSocketConnection(WebSocket webSocket , string token)
        {
            var buffer = new byte[1024 * 4];//4KB
            WebSocketReceiveResult? result = null; // אחסון תוצאת של הקריאה
            do
            {
                try
                {
                    result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);// מאזין 
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex is WebSocketException ?
                        $"WebSocket error: The client closed the connection incorrectly. New messages cannot be listened to." :
                        $"Unexpected error: {ex.Message}");
                }
            }
            while (result?.CloseStatus.HasValue != true && webSocket.State == WebSocketState.Open);

            try
            {
                await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, result?.CloseStatusDescription, CancellationToken.None);// סגירת החיבור
            }
            catch (Exception ex)
            {
                Console.WriteLine("WebSocket error during closing: " + ex.Message);
            }

            RemoveWebSocket(token);
        }

        public static async Task SendMessageAsyncWithSocket(string username, string json)
        {
            var buffer = Encoding.UTF8.GetBytes(json);
            if (_userSockets.TryGetValue(username,out var socket) && socket.State == WebSocketState.Open)
            {
                await socket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None);
                Console.WriteLine($"username : {username} , need to get messgae '{json}'");
            }
            else
            {
                Console.WriteLine($"Socket for user {username} is not open or doesn't exist.");
            }
        }


        private void RemoveWebSocket(string token)
        {
            _userSockets.TryRemove(token, out _);
        }
    }
}
