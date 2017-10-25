using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage="You have to enter e-mail")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "You have to enter password")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "You have to enter e-mail")]
        [EmailAddress(ErrorMessage = "E-mail is wrong")]
        public string Email { get; set; }

        [Required(ErrorMessage = "You have to enter password")]
        [StringLength(30, ErrorMessage = "{0} have to include at least {2} characters.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = " Password ")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = " Confirm Password ")]
        [Compare("Password", ErrorMessage ="Passwords are not the same.")]
        public string ConfirmPassword { get; set; }
    }
}