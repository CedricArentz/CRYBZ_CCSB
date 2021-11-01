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
        public Task<int> AddUpdate(AppointmentViewModel model);
        public List<AppointmentViewModel> EmployeeAppointments(string employeeid);
        public List<AppointmentViewModel> CustomerAppointments(string customerid);
        public AppointmentViewModel GetById(int id);
        public Task<int> DeleteAppointment(int id);
        public Task<int> ConfirmAppointment(int id);
    }
}
