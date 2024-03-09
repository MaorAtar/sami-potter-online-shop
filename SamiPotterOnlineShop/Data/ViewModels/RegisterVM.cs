using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace SamiPotterOnlineShop.Data.ViewModels
{
    public class RegisterVM
    {
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name is required")]
        public string FullName { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Confirm Password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Credit Card Number - CREDIT NUMBER-EXP[MM/YY]-CVV Format")]
        [Required(ErrorMessage = "Credit Card Number is required")]
        public string CreditCardNumber { get; set; }
    }
}
