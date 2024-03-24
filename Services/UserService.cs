using CodeMasters.Context;
using CodeMasters.Dtos.UserDtos;
using CodeMasters.Interfaces;
using CodeMasters.Models;
using CodeMasters.Responses;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CodeMasters.Services
{
    public class UserService : IUser
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;

        public UserService(IConfiguration configuration, ApplicationDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        public async Task<LoginResponse> Login(LoginUserDto userLogins)
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.Email == userLogins.Email && u.Password == userLogins.Password);

            if (user == null)
            {
                return new LoginResponse { Message = "Invalid email or password", Token = null };
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName)
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var userToken = tokenHandler.WriteToken(token);

            return new LoginResponse { Id =user.Id ,Username = user.UserName,Message = "Login successful", Token = userToken };
        }

        public async Task<int> Register(RegisterUserDto registerUserDto)
        {
            var newUser = new User
            {
                UserName = registerUserDto.UserName,
                Email = registerUserDto.Email,
                Password = registerUserDto.Password,
                ConfirmPassword = registerUserDto.ConfirmPassword,
                Age = registerUserDto.Age,
                Role = registerUserDto.Role,
                PhoneNumber = registerUserDto.PhoneNumber
            };

            _context.User.Add(newUser);
            await _context.SaveChangesAsync();

            return newUser.Id;
        }
    }
}
