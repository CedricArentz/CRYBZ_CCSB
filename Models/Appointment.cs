using CRYBZ_CCSB.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRYBZ_CCSB.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Action { get; set; }
        public List<Vehicle> Vehicles { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser Owner { get; set; }
    }
}
