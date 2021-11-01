using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRYBZ_CCSB.Models.ViewModels
{
    public class VehicleViewModel
    {
        [Key]
        [DisplayName("Kenteken")]
        [Required(ErrorMessage = "{0} is een verplicht veld.")]
        [RegularExpression(@"((\w{2}-\w{2}-\w{2})|(\w{2}-\w{3}-\w{1})|(\w{1}-\w{3}-\w{2})|(\w{3}-\w{2}-\w{1})|(\w{1}-\w{2}-\w{3}))"), StringLength(8)]
        public string LicencePlate { get; set; }

        [DisplayName("Voertuig Type")]
        [Required(ErrorMessage = "{0} is een verplicht veld.")]
        public string VehicleType { get; set; }

        [DisplayName("Lengte (in cm)")]
        [Required(ErrorMessage = "{0} is een verplicht veld.")]
        [Range(200, 2000, ErrorMessage = "Alleen positieve getallen toegestaan")]
        public int Length { get; set; }

        [DisplayName("Merk")]
        [Required(ErrorMessage = "{0} is een verplicht veld.")]
        public string Brand { get; set; }

        [DisplayName("Type")]
        [Required(ErrorMessage = "{0} is een verplicht veld.")]
        public string Type { get; set; }

        [DisplayName("Eigenaar")]
        [Required(ErrorMessage = "{0} is een verplicht veld.")]
        public string CustomerId { get; set; }
    }
}