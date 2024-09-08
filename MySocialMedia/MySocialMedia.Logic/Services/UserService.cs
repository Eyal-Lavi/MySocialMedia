using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
    public class UserService : IUserService
    {
        private readonly MySocialMediaDBContext _context;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        private readonly IMessageService _messageService;

        public UserService(MySocialMediaDBContext context , IMapper mapper , ITokenService tokenService ,IMessageService messageService)
        {
            _context = context;
            _mapper = mapper;
            _tokenService = tokenService;
            _messageService = messageService;
        }
        public async Task<bool> UserRegister(UserCreationDTO userCreationDTO)
        {
            var userExists = await UserExists(userCreationDTO.UserName);

            if (userExists)
            {
                return false;
            }
            var user = _mapper.Map<User>(userCreationDTO);
            _context.users.Add(user);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<LoginResponseDTO> UserLogin(UserLoginDTO userLoginDTO)
        {
            var user = await GetUser(userLoginDTO.UserName , userLoginDTO.Password);
            
            if (user != null)
            {
                var loginResponse = new LoginResponseDTO
                {
                    UserId = user.Id,
                    AuthToken = _tokenService.GenerateToken(userLoginDTO.UserName),
                    Chats = await _messageService.GetChatsSummary(userLoginDTO.UserName),
                };
                return loginResponse;
            }
            return null;
        }
        public async Task<bool> UserExists(string username)
        {
            var exists = await _context.users.AnyAsync(x => x.USER_NAME == username);
            return exists;
        }
        public async Task<int> GetUserId(string username)
        {
            var exists = await _context.users.FirstOrDefaultAsync(x => x.USER_NAME == username);
            if(exists != null)
            {
                return exists.ID;
            }
            return -1;
        }
        public async Task<UserDTO> GetUser(string username , string password)
        {
            var result = await _context.users.FirstOrDefaultAsync(x => x.USER_NAME == username && x.PASSWORD == password);
            var user = _mapper.Map<UserDTO>(result);
            return user;
        }
    }
}
