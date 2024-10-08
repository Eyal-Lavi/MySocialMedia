﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySocialMedia.Common.DBTables.MessageDTOs
{
    public class UserMessageDTO
    {
        public int Id { get; set; } // מזהה ייחודי של ההודעה
        public int SenderUserId { get; set; } // מזהה המשתמש ששלח את ההודעה
        public int ReceiverUserId { get; set; } // מזהה המשתמש שקיבל את ההודעה
        public string? MessageData { get; set; } // תוכן ההודעה
        public DateTime MessageDate { get; set; } // תאריך שליחת ההודעה
        public virtual User? SendUser { get; set; } // משתמש ששלח את ההודעה
        public virtual User? ReceiveUser { get; set; } // משתמש שקיבל את ההודעה
    }
}
