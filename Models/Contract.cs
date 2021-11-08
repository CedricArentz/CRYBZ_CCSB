using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRYBZ_CCSB.Models
{
    public class Contract
    {
        [Key]
        public int ContractID { get; set; }

        [DisplayName("Start Datum")]
        [Required(ErrorMessage = "{0} is een verplicht veld.")]
        [RegularExpression(@"^(0[1-9]|1[012])[-](0[1-9]|[12][0-9]|3[01])[-]\d{4}$", ErrorMessage = "Start Date should be in MM-dd-yyyy format")]
        public string StartDate { get; set; }

        [DisplayName("Eind Datum")]
        [RegularExpression(@"^(0[1-9]|1[012])[-](0[1-9]|[12][0-9]|3[01])[-]\d{4}$", ErrorMessage = "End Date should be in MM-dd-yyyy format")]
        public string EndDate { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser Owner { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}