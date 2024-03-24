using CodeMasters.Dtos.UserDtos;
using CodeMasters.Responses;

namespace CodeMasters.Interfaces
{
    public interface IUser
    {
        Task<int> Register(RegisterUserDto registerUserDto);
        Task<LoginResponse>Login(LoginUserDto loginUserDto);
    }
}
