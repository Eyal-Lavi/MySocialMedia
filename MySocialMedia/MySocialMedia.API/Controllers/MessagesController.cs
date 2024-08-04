using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MySocialMedia.Common.DBTables.MessageDTOs;
using MySocialMedia.Logic.Services;

namespace MySocialMedia.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/messages")]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly ILogger _logger;

        public MessagesController(IMessageService messageService , ILogger<MessagesController> logger)
        {
            _messageService = messageService;
            _logger = logger;
        }
        [HttpPost("send")]
        public async Task<ActionResult> SendMessage([FromBody] UserMessageCreationDTO userMessageCreationDTO) 
        {
            var usernameClaim = User.Claims.FirstOrDefault(x => x.Type == "username");
            var username = usernameClaim?.Value;
            Console.WriteLine(username);

            await _messageService.SendMessage(userMessageCreationDTO);

            return Ok(true);
        }
        [HttpGet("allMessages")]
        public async Task<ActionResult> GetAllChatWith([FromQuery] string targetUser)
        {
            var myUserNameClaim = User.Claims.FirstOrDefault(x => x.Type == "username");
            var currentUser = myUserNameClaim?.Value;

            if (string.IsNullOrEmpty(currentUser))
            {
                _logger.LogWarning("The controller has been verified but cannot find its username according to the token");
                return Unauthorized();
            }

            var messages = await _messageService.GetMessagesForSpesificUser(currentUser ,targetUser);

            var logValue = messages == null || !messages.Any() ?
                $"No messages found between {currentUser} and {targetUser}." :
                $"Have {messages.Count} messages ";

            _logger.LogWarning(logValue);
            return Ok(messages);
        }
    }
}
