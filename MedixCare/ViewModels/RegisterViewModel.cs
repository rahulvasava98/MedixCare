using System.ComponentModel.DataAnnotations;

namespace MedixCare.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Full Name")]
        public string? FullName { get; set; }

        [Required]

        public string Email { get; set; }   

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password",ErrorMessage = "Password do not match"),DataType(DataType.Password)]
        [Display(Name = "confirm Password")]
        public string ConfirmPassword { get; set; }


        public string Role {  get; set; }  // DropDown in View 


    }
}
