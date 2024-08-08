using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MySocialMedia.Common.DTOs.UserDTOs;
using MySocialMedia.Common.DTOs.utlisDTOs;
using MySocialMedia.Logic;
using MySocialMedia.Logic.Services;

namespace MySocialMedia.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly MySocialMediaDBContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService,ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }
        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Register([FromBody] UserCreationDTO userCreationDTO)
        {
            userCreationDTO.DateCreate = DateTime.Now;
            var result = await _userService.UserRegister(userCreationDTO);

            if (!result)
            {
                return BadRequest("Username already exists");//400
            }
            
            return Created();//201
        }
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<LoginResponseDTO>> Login([FromBody] UserLoginDTO userLoginDTO)
        {
            var userResponse = await _userService.UserLogin(userLoginDTO);

            if (userResponse == null)
            {
                return NotFound();
            }
           return userResponse;
        }
    }
}
