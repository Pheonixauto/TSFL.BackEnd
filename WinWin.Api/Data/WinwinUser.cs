using Microsoft.AspNetCore.Identity;

namespace WinWin.Api.Data
{
    public class WinwinUser : IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public string? MiddleName { get; set; } 
        public string LastName { get; set; } = null!;
    }
}
