using Microsoft.AspNetCore.Identity;

namespace MedixCare.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }

        public string Role {  get; set; } //for easier access


        //ROles Handles via IdentityRole
        public ICollection<Notification>? Notifications { get; set; }
    }
}
