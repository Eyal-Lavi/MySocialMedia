using MySocialMedia.Common.DBTables;
using MySocialMedia.Common.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySocialMedia.Logic.Services
{
    public interface IUserService
    {
        Task<User?> GetUserByCredentials(string username, string password);
        Task<bool> UserRegister(UserCreationDTO userCreationDTO);
        Task<bool> UserExists(UserCreationDTO userCreationDTO);
        Task<bool> UserLogin(UserLoginDTO userLoginDTO);
    }
}
