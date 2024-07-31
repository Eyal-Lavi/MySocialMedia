using MySocialMedia.Common.DBTables;
using MySocialMedia.Common.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySocialMedia.Common.DTOs.UserDTOs
{
    public class UserCreationDTO // ישות ליצירת משתמש עם ולידציות
    {
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        [StringLength(16,MinimumLength = 2)]
        public string? UserName { get; set; }
        [Required]
        [StringLength(16,MinimumLength = 8)]
        [OneCharacterIsBigLetter]
        [OneCharacterIsSmallLetter]
        public string? Password { get; set; }
        [Required]
        public DateTime DateCreate { get; set; }
    }
}