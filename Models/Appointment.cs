using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRYBZ_CCSB.Models
{
    public class Appointment
    {
        [Key]
        public string Date { get; set; }
        public string Action { get; set; }
        public string LicensePlate { get; set; }
    }
}
