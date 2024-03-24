using CodeMasters.Context;
using CodeMasters.Dtos.UserDtos;
using CodeMasters.Interfaces;
using CodeMasters.Models;
using CodeMasters.Responses;
using CodeMasters.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CodeMasters.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly IUser _userServices;
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;

        public UserController(IUser UserServices, IConfiguration configuration, ApplicationDbContext context)
        {
            _userServices = UserServices;
            _configuration = configuration;
            _context = context;
        }


        [HttpPost("register")]
        [AllowAnonymous]

        public async Task<IActionResult> Register([FromBody] RegisterUserDto registerUserDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            int userId = await _userServices.Register(registerUserDto);
            return Ok(new { UserId = userId });
        }

        [HttpPost("login")]
        [AllowAnonymous]

        public async Task<IActionResult> Login([FromBody]LoginUserDto loginUserDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            LoginResponse response = await _userServices.Login(loginUserDto);
            if (response.Token == null)
            {
                return Unauthorized(response);
            }

            return Ok(response);
        }
    }
}
