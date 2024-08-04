using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySocialMedia.Common.DTOs.utlisDTOs
{
    public class ChatSummaryDTO
    {
        public int ChatId { get; set; }
        public string ChatName { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
