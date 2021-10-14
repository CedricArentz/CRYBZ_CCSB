using CRYBZ_CCSB.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRYBZ_CCSB.Services
{
    public interface IAppointmentService
    {
        public List<EmployeeViewModel> GetEmployeeList();
        public List<CustomerViewModel> GetCustomerList();
        public List<AppointmentViewModel> GetVehicleList();
        public Task<int> AddUpdate(AppointmentViewModel model);
    }
}
