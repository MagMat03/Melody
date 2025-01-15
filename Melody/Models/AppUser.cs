using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Melody.Models
{
    public class AppUser : IdentityUser
    {
        public bool IsArtist { get; set; }
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
     
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
    }
}
