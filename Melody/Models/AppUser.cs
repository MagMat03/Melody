using Microsoft.AspNetCore.Identity;

namespace Melody.Models
{
    public class AppUser : IdentityUser
    {
        public bool IsArtist { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
