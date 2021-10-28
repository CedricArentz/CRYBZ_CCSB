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
        public string LicencePlate { get; set; }

        [DisplayName("Voertuig Type")]
        [Required(ErrorMessage = "{0} is een verplicht veld.")]
        public string VehicleType { get; set; }

        [DisplayName("Lengte (in cm)")]
        [Required(ErrorMessage = "{0} is een verplicht veld.")]
        [DataType(DataType.Custom)]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$")]
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