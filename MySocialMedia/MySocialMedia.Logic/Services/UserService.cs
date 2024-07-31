using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MySocialMedia.Common.DBTables;
using MySocialMedia.Common.DTOs.UserDTOs;
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

        public UserService(MySocialMediaDBContext context , IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<User?> GetUserByCredentials(string username , string password)
        {
            return await _context.users.FirstOrDefaultAsync(x => x.USER_NAME == username && x.PASSWORD == password);
        }
        public async Task<bool> UserRegister(UserCreationDTO userCreationDTO)
        {
            var userExists = await UserExists(userCreationDTO);

            if (userExists)
            {
                return false;
            }
            var user = _mapper.Map<User>(userCreationDTO);
            _context.users.Add(user);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UserExists(UserCreationDTO userCreationDTO)
        {
            var exists = await _context.users.AnyAsync(x => x.USER_NAME == userCreationDTO.UserName);

            return exists;
        }
        public async Task<bool> UserLogin(UserLoginDTO userLoginDTO)
        {
            var exists = await _context.users.AnyAsync(x => x.USER_NAME == userLoginDTO.UserName && x.PASSWORD == userLoginDTO.Password);

            return exists;
        }
    }
}
