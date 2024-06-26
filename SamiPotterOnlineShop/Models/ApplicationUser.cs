﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SamiPotterOnlineShop.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "Credit Card Number")]
        public string CreditCardNumber { get; set; }

        public bool Notified { get; set; }
        public int NotifyItemId { get; set; }
    }
}
