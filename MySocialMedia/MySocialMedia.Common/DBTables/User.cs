using MySocialMedia.Common.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySocialMedia.Common.DBTables
{
    [Table("users")] // הגדרת שם הטבלה במסד הנתונים
    public class User //ישות להוציא ולהכניס משתמש למסד נתונתים
    {
        public int ID { get; set; } // מזהה ייחודי של המשתמש
        [Required]
        public string? FIRST_NAME { get; set; } // שם פרטי
        [Required]
        public string? LAST_NAME { get; set; } // שם משפחה
        [Required]
        [StringLength(16,MinimumLength = 2)]
        public string? USER_NAME { get; set; } // שם משתמש
        [Required]
        [StringLength(16)]
        [OneCharacterIsBigLetter]
        [OneCharacterIsSmallLetter]
        public string? PASSWORD { get; set; } // סיסמה
        [Required]
        public DateTime DATE_CREATE { get; set; } // תאריך יצירת החשבון

        public virtual ICollection<User_messages>? send_user_messages { get; set; } // הודעות שנשלחו
        public virtual ICollection<User_messages>? receive_user_messages { get; set; } // הודעות שהתקבלו
    }
}
