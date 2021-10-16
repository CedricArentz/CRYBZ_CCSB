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
    public class VehicleService : IVehicleService
    {
        private readonly ApplicationDbContext _db;
        public VehicleService(ApplicationDbContext db)
        {
            _db = db;
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

        public async Task<int> AddUpdate(VehicleViewModel model)
        { 
            if (model != null && model.LicencePlate != null)
            {
                //TODO: Add code for update appointment
                return 1;
            }
            else
            {
                //Create appointment based on view model
                Vehicle vehicle = new Vehicle()
                {
                    LicencePlate = model.LicencePlate,
                    VehicleType = model.VehicleType,
                    Length = model.Length,
                    Brand = model.Brand,
                    Type = model.Type,
                    CustomerId = model.CustomerId,
                };
                _db.Vehicles.Add(vehicle);
                await _db.SaveChangesAsync();
                return 2;
            }
        }
    }
}
