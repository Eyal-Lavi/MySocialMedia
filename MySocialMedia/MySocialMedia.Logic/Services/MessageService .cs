using AutoMapper;
using Microsoft.AspNetCore.WebSockets;
using Microsoft.EntityFrameworkCore;
using MySocialMedia.API.Middlwares;
using MySocialMedia.Common.DBTables;
using MySocialMedia.Common.DBTables.MessageDTOs;
using MySocialMedia.Common.DTOs.utlisDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
namespace MySocialMedia.Logic.Services
{
    public class MessageService : IMessageService
    {
        private readonly MySocialMediaDBContext _context;
        private readonly IMapper _mapper;
        public MessageService(MySocialMediaDBContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<List<UserMessageDTO>> GetMessagesForSpesificUser(string currentUser, string targetUser)
        {
            var messagesList = await _context.user_messages
               .Include(ms => ms.send_user)
               .Include(ms => ms.receive_user)
               .Where(ms => (ms.send_user.USER_NAME == targetUser && ms.receive_user.USER_NAME == currentUser) ||
                            (ms.send_user.USER_NAME == currentUser && ms.receive_user.USER_NAME == targetUser))
               .OrderBy(ms => ms.MESSAGE_DATE)
               .ToListAsync();

            var newMessagesList = _mapper.Map<List<UserMessageDTO>>(messagesList);
            return newMessagesList;
        }

        public async Task SendMessage(UserMessageCreationDTO userMessageCreationDTO)
        {
            var message = _mapper.Map<UserMessage>(userMessageCreationDTO);
            _context.user_messages.Add(message);
            await _context.SaveChangesAsync();

            var reciverdUser = _context.users.FirstOrDefault(x => x.ID == userMessageCreationDTO.ReceiverUserId);
            var messageToSend = _mapper.Map<UserMessageDTO>(message);
            var json = JsonSerializer.Serialize(messageToSend);

            await MyWebSocketMiddleware.SendMessageAsyncWithSocket(reciverdUser.USER_NAME , json);

        }
        public async Task<List<ChatSummaryDTO>> GetChatsSummary(string currentUser)
        {
            var sentMessagesUserNames = _context.user_messages
                .Where(ms => ms.send_user.USER_NAME == currentUser) // כשהשולח ההודעה הוא אתה
                .Select(ms => new ChatSummaryDTO // תיקח את הפרטים של המקבל
                {
                    ChatId = ms.receive_user.ID,
                    ChatName = ms.receive_user.USER_NAME,
                    FirstName = ms.receive_user.FIRST_NAME,
                    LastName = ms.receive_user.LAST_NAME
                });

            var receivedMessagesUserNames = _context.user_messages
                .Where(ms => ms.receive_user.USER_NAME == currentUser) // כשהמקבל ההודעה הוא אתה
                .Select(ms => new ChatSummaryDTO // תיקח את הפרטים של השולח
                {
                    ChatId = ms.send_user.ID,
                    ChatName = ms.send_user.USER_NAME,
                    FirstName = ms.send_user.FIRST_NAME,
                    LastName = ms.send_user.LAST_NAME
                });

            // איחוד שתי הרשימות של ההודעות והמרה לרשימה
            var listChatSummary = await sentMessagesUserNames
                .Union(receivedMessagesUserNames)
                .ToListAsync();

            return listChatSummary;
        }
    }
}
