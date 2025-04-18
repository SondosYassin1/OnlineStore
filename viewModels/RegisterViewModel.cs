using System.ComponentModel.DataAnnotations;

namespace OnlineStore.viewModels
{
    public class RegisterViewModel
    {
        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; } = string.Empty;


        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; } = string.Empty;



        [Display(Name = "Email")]
        [Required]
        [EmailAddress]
        public string Email { get; set; }


        [Display(Name = "Password")]
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Display(Name = "Confirme Password")]
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match!")]
        public string ConfirmPassword { get; set; }
        
    }
}
