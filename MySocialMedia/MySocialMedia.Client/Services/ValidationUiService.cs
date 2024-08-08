using MySocialMedia.Common.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySocialMedia.Client.Services
{
    public static class ValidationUiService
    {
        public static string? Username(string userName)
        {
            if(userName == null)
            {
                return "Cannot be Null";
            }
            if(userName.Length < 2)
            {
                return "The Minimum Length is 2";
            }
            return null;
        }
        public static string? Password(string password)
        {
            if (password == null)
            {
                return "Cannot be Null";
            }
            if (password.Length < 8)
            {
                return "The Minimum Length is 8";
            }
            if(!password.Any(x => x >= 'A' && x <= 'Z'))
            {
                return "Must be 1 charter that is big letter";
            }
            if (!password.Any(x => x >= 'a' && x <= 'z'))
            {
                return "Must be 1 charter that is small letter";
            }
            return null;
        }
        public static string? FirstName(string firstName)
        {
            if (firstName == null)
            {
                return "Cannot be Null";
            }
            if (firstName.Length == 0)
            {
                return "Cannot be empty";
            }
            if (firstName.Any(char.IsDigit))
            {
                return "Cannot contain digit";
            }
            return null;
        }
        public static string? LastName(string lastName)
        {
            if (lastName == null)
            {
                return "Cannot be Null";
            }
            if (lastName.Length == 0)
            {
                return "Cannot be empty";
            }
            if (lastName.Any(char.IsDigit))
            {
                return "Cannot contain digit";
            }
            return null;
        }
        public static List<string> CheckAllParamsLogin(UserLoginDTO userCreationDTO)
        {
            List<string> errors = new List<string>();

            if (userCreationDTO == null)
            {
                throw new ArgumentNullException(nameof(userCreationDTO) + " - Cannot be Null");
            }

            var usernameValiRespo = Username(userCreationDTO.UserName);
            var passwordValiRespo = Password(userCreationDTO.Password);

            if (usernameValiRespo != null)
            {
                errors.Add(usernameValiRespo);
            }
            if (passwordValiRespo != null)
            {
                errors.Add(passwordValiRespo);
            }
            return errors;
        }
        public static List<string> CheckAllParamsRegister(UserCreationDTO userCreationDTO)
        {
            List<string> errors = new List<string>();
            if(userCreationDTO == null)
            {
                throw new ArgumentNullException(nameof(userCreationDTO) + " - Cannot be Null");
            }

            var usernameValiRespo = Username(userCreationDTO.UserName);
            var passwordValiRespo = Password(userCreationDTO.Password);
            var firstnameValiRespo = FirstName(userCreationDTO.FirstName);
            var lastnameValiRespo = LastName(userCreationDTO.LastName);

            if(usernameValiRespo != null)
            {
                errors.Add(usernameValiRespo);
            }
            if(passwordValiRespo != null)
            {
                errors.Add(passwordValiRespo);
            }
            if (firstnameValiRespo != null)
            {
                errors.Add(firstnameValiRespo);

            }
            if (lastnameValiRespo != null)
            {
                errors.Add(lastnameValiRespo);
            }

            return errors;
        }
    }
}
