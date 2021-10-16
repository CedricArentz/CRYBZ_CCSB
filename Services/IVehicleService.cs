using CRYBZ_CCSB.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRYBZ_CCSB.Services
{
    public interface IVehicleService
    {
        public List<CustomerViewModel> GetCustomerList();
        public Task<int> AddUpdate(VehicleViewModel model);
    }
}
