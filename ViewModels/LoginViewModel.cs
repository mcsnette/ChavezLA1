using System.ComponentModel.DataAnnotations;

namespace ChavezLA1.ViewModels
{

   
    public class LoginViewModel
    {
        
        [Display(Name = "User Name")]
        [Required(ErrorMessage = "a username is required")]
        public string? UserName;

        [Display(Name = "Password")]
        [Required(ErrorMessage = "a password is required")]
        public string? Password;

        [Display(Name = "Remember me?")]
        public bool RememberMe {  get; set; }

    }
}
