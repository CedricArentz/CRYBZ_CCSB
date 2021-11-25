using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRYBZ_CCSB.Models.ViewModels
{
    public class RegisterViewModel
    {
        [DisplayName("Voornaam*")]
        [Required(ErrorMessage = "{0} is een verplicht veld.")]
        public string FirstName { get; set; }

        [DisplayName("Tussenvoegsels")]
        public string MiddleName { get; set; }

        [DisplayName("Achternaam*")]
        [Required(ErrorMessage = "{0} is een verplicht veld.")]
        public string LastName { get; set; }

        [EmailAddress]
        [DisplayName("E-mailadres*")]
        [Required(ErrorMessage = "{0} is een verplicht veld.")]
        public string Email { get; set; }

        [DisplayName("Postcode*")]
        [Required(ErrorMessage = "{0} is een verplicht veld.")]
        [RegularExpression(@"(NL-)?([1-9]{4})\s*([A-Z]{2})", ErrorMessage = "Onjuiste Postcode")]  
        public string Zipcode { get; set; }

        [DisplayName("Straatnaam*")]
        [Required(ErrorMessage = "{0} is een verplicht veld.")]
        public string Straatnaam { get; set; }


        [DisplayName("Woonplaats*")]
        [Required(ErrorMessage = "{0} is een verplicht veld.")]
        public string Woonplaats { get; set; }

        [DisplayName("Huisnummer*")]
        [Required(ErrorMessage = "{0} is een verplicht veld.")]
        public string Huisnummer { get; set; }

        [Required(ErrorMessage = "{0} is een verplicht veld.")]
        [DataType(DataType.Password)]
        [DisplayName("Wachtwoord*")]
        [StringLength(100, ErrorMessage = "Het {0} moet minstens {2} tekens bevatten.",
            MinimumLength = 6)]
        public string Password { get; set; }

        [DisplayName("Bevestig wachtwoord*")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Wachtwoorden komen niet overeen")]
        public string PasswordConfirm { get; set; }

        [DisplayName("Rol*")]
        [Required(ErrorMessage = "{0} is een verplicht veld.")]
        public string RoleName { get; set; }
    }
}