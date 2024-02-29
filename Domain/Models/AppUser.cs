using Microsoft.AspNetCore.Identity;

namespace Domain.Models
{
    public class AppUser:IdentityUser
    {
        public string Gendre { get; set; }
        public DateTime StartingAt { get; set; }
    }
}
