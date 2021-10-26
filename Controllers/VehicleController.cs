using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRYBZ_CCSB.Models;
using CRYBZ_CCSB.Utility;
using CRYBZ_CCSB.Services;
using CRYBZ_CCSB.Models.ViewModels;

namespace CRYBZ_CCSB.Controllers
{
    public class VehicleController : Controller
    {
        private readonly ApplicationDbContext _db;
        IVehicleService _vehicleService;

        public VehicleController(ApplicationDbContext db,
            IVehicleService vehicleService)
        {
            _db = db;
            _vehicleService = vehicleService;
        }
        public IActionResult Index()
        {
            ViewBag.CustomerList = _vehicleService.GetCustomerList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveVehicleData(VehicleViewModel model)
        {
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
            return View();


            //CommonResponse<int> commonResponse = new CommonResponse<int>();
            //try
            //{
            //    commonResponse.Status = _vehicleService.AddUpdate(data).Result;
            //    if (commonResponse.Status == 1)
            //    {
            //        // Successful update
            //        commonResponse.Message = Helper.VehicleUpdated;
            //    }
            //    if (commonResponse.Status == 2)
            //    {
            //        // Successful addition
            //        commonResponse.Message = Helper.VehicleAdded;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    commonResponse.Message = ex.Message;
            //    commonResponse.Status = Helper.Failure_code;
            //}
            //return Ok(commonResponse);
        }
        //public async Task<int> AddUpdate(VehicleViewModel model)
        //{
        //    if (model != null && model.LicencePlate == null)
        //    {
        //        //TODO: Add code for update appointment
        //        return 1;
        //    }
        //    else
        //    {
        //        //Create appointment based on view model
        //        Vehicle vehicle = new Vehicle()
        //        {
        //            LicencePlate = model.LicencePlate,
        //            VehicleType = model.VehicleType,
        //            Length = model.Length,
        //            Brand = model.Brand,
        //            Type = model.Type,
        //            CustomerId = model.CustomerId,
        //        };
        //        _db.Vehicles.Add(vehicle);
        //        await _db.SaveChangesAsync();
        //        return 2;
        //    }
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Register(RegisterViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        ApplicationUser user = new ApplicationUser()
        //        {
        //            UserName = model.Email,
        //            Email = model.Email,
        //            FirstName = model.FirstName,
        //            MiddleName = model.MiddleName,
        //            LastName = model.LastName
        //        };
        //        var result = await _userManager.CreateAsync(user, model.Password);
        //        if (result.Succeeded)
        //        {
        //            // Assign role to user and log the user in and redirect to the homepage
        //            await _userManager.AddToRoleAsync(user, model.RoleName);
        //            await _signInManager.SignInAsync(user, isPersistent: false);
        //            return RedirectToAction("Index", "Home");
        //        }
        //        //Add all errors to the modelstate
        //        foreach (var error in result.Errors)
        //        {
        //            ModelState.AddModelError("", error.Description);
        //        }
        //    }
        //    return View();
        //}
    }
}
