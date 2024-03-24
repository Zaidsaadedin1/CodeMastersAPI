using Microsoft.AspNetCore.Identity;

namespace CodeMasters.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public int Age { get; set; }
        public string Role { get; set; }
        public string PhoneNumber { get; set; }

    }
}
