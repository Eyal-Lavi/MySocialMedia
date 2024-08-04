using MySocialMedia.Common.DBTables;
using MySocialMedia.Common.DBTables.MessageDTOs;
using MySocialMedia.Common.DTOs.utlisDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySocialMedia.Logic.Services
{
    public interface IMessageService
    {
        Task<List<ChatSummaryDTO>> GetChatsSummary(string currentUser);
        Task<List<UserMessageDTO>> GetMessagesForSpesificUser(string currentUser, string targetUser);
        Task SendMessage(UserMessageCreationDTO userMessageCreationDTO);
    }
}
