using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySocialMedia.Common.DBTables.MessageDTOs
{
    public class UserMessageCreationDTO
    {
        [Required]
        public int SenderUserId { get; set; } // מזהה המשתמש ששלח את ההודעה
        [Required]
        public int ReceiverUserId { get; set; } // מזהה המשתמש שקיבל את ההודעה
        [Required]
        [StringLength(maximumLength:1000,MinimumLength = 1)]
        public string? MessageData { get; set; } // תוכן ההודעה
        public DateTime MessageDate { get; set; } // תאריך שליחת ההודעה
    }
}
