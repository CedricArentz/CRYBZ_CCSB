﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CRYBZ_CCSB.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "{0} is een verplicht veld.")]
        [EmailAddress(ErrorMessage ="Dit is geen geldig e-mailadres")]
        [Display(Name ="E-mail")]
        public string Email { get; set; }
        [Required(ErrorMessage = "{0} is een verplicht veld.")]
        [DataType(DataType.Password)]
        [Display(Name = "Wachtwoord")]
        public string Password { get; set; }
        [Display(Name ="Onthoud mij")]
        public bool RememberMe { get; set; }
    }
}
