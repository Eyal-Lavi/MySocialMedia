using MySocialMedia.Common.DBTables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySocialMedia.Common.DTOs.UserDTOs
{
    public class UserDTO// משתמש להעברת נתונים
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public DateTime DateCreate { get; set; }
        public virtual ICollection<UserMessage>? SendUserMessages { get; set; }
        public virtual ICollection<UserMessage>? ReceiveUserMessages { get; set; }
    }
}
