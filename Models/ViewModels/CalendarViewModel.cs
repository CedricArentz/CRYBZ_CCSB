using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRYBZ_CCSB.Models.ViewModels
{
    public class CalanderViewModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public string Type { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public bool allDay { get; set; } = false;
    }
}
