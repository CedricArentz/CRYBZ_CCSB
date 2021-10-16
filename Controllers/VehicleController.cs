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
        private readonly IVehicleService _vehicleService;
        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }
        public IActionResult Index()
        {
            ViewBag.CustomerList = _vehicleService.GetCustomerList();
            return View();
        }
        public IActionResult SaveVehicleData(VehicleViewModel data)
        {
            CommonResponse<int> commonResponse = new CommonResponse<int>();
            try
            {
                commonResponse.Status = _vehicleService.AddUpdate(data).Result;
                if (commonResponse.Status == 1)
                {
                    // Successful update
                    commonResponse.Message = Helper.VehicleUpdated;
                }
                if (commonResponse.Status == 2)
                {
                    // Successful addition
                    commonResponse.Message = Helper.VehicleAdded;
                }
            }
            catch (Exception ex)
            {
                commonResponse.Message = ex.Message;
                commonResponse.Status = Helper.Failure_code;
            }
            return Ok(commonResponse);
        }
    }
}
