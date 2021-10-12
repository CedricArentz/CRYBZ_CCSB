using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRYBZ_CCSB.Models
{
    //Datatabel is declared here for Contract
    public class Contract
    {
        //ContractID is a primary key
        public int ContractID { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
