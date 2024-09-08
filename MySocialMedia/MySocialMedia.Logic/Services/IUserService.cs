using MySocialMedia.Common.DBTables;
using MySocialMedia.Common.DTOs.UserDTOs;
using MySocialMedia.Common.DTOs.utlisDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySocialMedia.Logic.Services
{
    public interface IUserService
    {
        Task<bool> UserRegister(UserCreationDTO userCreationDTO);
        Task<bool> UserExists(string username);
        Task<LoginResponseDTO> UserLogin(UserLoginDTO userLoginDTO);
        Task<UserDTO> GetUser(string username , string password);
        Task<int> GetUserId(string username);
    }
}
