﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MySocialMedia.Common.DBTables
{
    [Table("users_messages")] // הגדרת שם הטבלה במסד הנתונים
    public class UserMessage
    {
        public int ID { get; set; } // מזהה ייחודי של ההודעה
        [Required]
        public int SENDER_USER_ID { get; set; } // מזהה המשתמש ששלח את ההודעה
        [Required]
        public int RECEIVER_USER_ID { get; set; } // מזהה המשתמש שקיבל את ההודעה
        [Required]
        [StringLength(maximumLength:1000,MinimumLength = 1)]
        public string? MESSAGE_DATA { get; set; } // תוכן ההודעה
        [Required]
        public DateTime MESSAGE_DATE { get; set; } // תאריך שליחת ההודעה
        [JsonIgnore]
        public virtual User? send_user { get; set; } // משתמש ששלח את ההודעה
        [JsonIgnore]
        public virtual User? receive_user { get; set; } // משתמש שקיבל את ההודעה
    }
}
