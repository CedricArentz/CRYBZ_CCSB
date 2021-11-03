using CRYBZ_CCSB.Models.ViewModels;
using CRYBZ_CCSB.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRYBZ_CCSB.Controllers;
using CRYBZ_CCSB.Models;
using System.Globalization;

namespace CRYBZ_CCSB.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly ApplicationDbContext _db;

        public AppointmentService(ApplicationDbContext db)
        {
            _db = db;
        }
        public List<EmployeeViewModel> GetEmployeeList()
        {
            var employees = (from user in _db.Users
                             join userRole in _db.UserRoles on user.Id equals userRole.UserId
                             join role in _db.Roles.Where(x => x.Name == Helper.Employee) on userRole.RoleId equals role.Id
                             select new EmployeeViewModel
                             {
                                 Id = user.Id,
                                 Name = string.IsNullOrEmpty(user.MiddleName) ?
                                 user.FirstName + " " + user.LastName :
                                 user.FirstName + " " + user.MiddleName + " " + user.LastName
                             }
                             ).OrderBy(u => u.Name).ToList();
            return employees;
        }
        public List<CustomerViewModel> GetCustomerList()
        {
            var customers = (from user in _db.Users
                             join userRole in _db.UserRoles on user.Id equals userRole.UserId
                             join role in _db.Roles.Where(x => x.Name == Helper.Customer) on userRole.RoleId equals role.Id
                             select new CustomerViewModel 
                             {
                                 Id = user.Id,
                                 Name = string.IsNullOrEmpty(user.MiddleName) ?
                                 user.FirstName + " " + user.LastName :
                                 user.FirstName + " " + user.MiddleName + " " + user.LastName
                             }
                             ).OrderBy(u => u.Name).ToList();
            return customers;
        }

        public List<AppointmentViewModel> GetVehicleList()
        {
            var appointment = (from Appointment in _db.Appointments
                               select new AppointmentViewModel
                               {
                                   Action = Appointment.Action,
                                   LicensePlate = Appointment.LicensePlate,
                                   Date = Convert.ToString(Appointment.Date)
                               }
                             ).OrderBy(a => a.Date).ToList();
            return appointment;
        }

        public async Task<int> AddUpdate(AppointmentViewModel model)
        {
            DateTime date = DateTime.Parse(model.Date, CultureInfo.CreateSpecificCulture("en-US"));
            if (model == null)
            {
                //TODO: Add code for update appointment
                return 1;
            }
            else
            {
                //Create appointment based on view model
                Appointment appointment = new Appointment()
                {
                    Date = (DateTime)date,
                    Action = model.Action,
                    LicensePlate = model.LicensePlate
                };
                _db.Appointments.Add(appointment);
                await _db.SaveChangesAsync();
                return 2;
            }
        }

        public AppointmentViewModel GetById(string licenseplate)
        {
            return _db.Appointments.Where(a => a.LicensePlate == licenseplate).ToList().Select(
                c => new AppointmentViewModel()
                {
                    LicensePlate = c.LicensePlate,
                    Action = c.Action
                }).SingleOrDefault();
        }
    }
}
