using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRYBZ_CCSB.Models.ViewModels
{
    public class ContractViewModel
    {
        [Key]
        public int ContractID { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string CustomerId { get; set; }
        public string LicencePlate { get; set; }
    }
}
