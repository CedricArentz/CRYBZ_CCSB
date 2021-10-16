using CRYBZ_CCSB.Models.ViewModels;
using CRYBZ_CCSB.Services;
using CRYBZ_CCSB.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CRYBZ_CCSB.Controllers.API
{
    [Route("API/[controller]")]
    [ApiController]
    public class VehicleApiController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string loginUserId;
        private readonly string role;
        public VehicleApiController(IVehicleService vehicleService, IHttpContextAccessor httpContextAccessor)
        {
            _vehicleService = vehicleService;
            _httpContextAccessor = httpContextAccessor;
            loginUserId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            role = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Role);
        }
        [HttpPost]
        [Route("SaveVehicleData")]
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
