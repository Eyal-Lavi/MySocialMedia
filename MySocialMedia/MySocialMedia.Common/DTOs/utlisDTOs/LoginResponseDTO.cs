using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySocialMedia.Common.DTOs.utlisDTOs
{
    public class LoginResponseDTO
    {
        public int UserId { get; set; }
        public string AuthToken { get; set; }
        public List<ChatSummaryDTO> Chats { get; set; }
    }
}
