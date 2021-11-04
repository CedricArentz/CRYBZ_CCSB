using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRYBZ_CCSB.Models.ViewModels
{
    public class ContractViewModel
    {
        [Key]
        public int ContractID { get; set; }

        [DisplayName("Start Datum")]
        [Required(ErrorMessage = "{0} is een verplicht veld.")]
        [RegularExpression(@"^(0[1-9]|1[012])[-](0[1-9]|[12][0-9]|3[01])[-]\d{4}$", ErrorMessage = "End Date should be in MM-dd-yyyy format")]
        public string StartDate { get; set; }

        [DisplayName("Eind Datum")]
        [Required(ErrorMessage = "{0} is een verplicht veld.")]
        [RegularExpression(@"^(0[1-9]|1[012])[-](0[1-9]|[12][0-9]|3[01])[-]\d{4}$", ErrorMessage = "End Date should be in MM-dd-yyyy format")]
        public string EndDate { get; set; }

        [DisplayName("Eigenaar")]
        [Required(ErrorMessage = "{0} is een verplicht veld.")]
        public string CustomerId { get; set; }
        
        [DisplayName("Kenteken")]
        [Required(ErrorMessage = "{0} is een verplicht veld.")]
        [RegularExpression(@"(\w{2}-\w{2}-\w{2})|(\w{2}-\w{3}-\w{1})|(\w{1}-\w{3}-\w{2})|(\w{3}-\w{2}-\w{1})|(\w{1}-\w{2}-\w{3})"), StringLength(8)]
        public string LicencePlate { get; set; }
    }
}
