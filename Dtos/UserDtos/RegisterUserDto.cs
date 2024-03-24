namespace CodeMasters.Dtos.UserDtos
{
    public class RegisterUserDto
    {
        public string? UserName { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string ConfirmPassword { get; set; } = null!;
        public int Age { get; set; }
        public string Role { get; set; } = null!;
        public string? PhoneNumber { get; set; }
    }
}
