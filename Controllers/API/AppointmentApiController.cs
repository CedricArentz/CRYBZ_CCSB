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
    public class AppointmentApiController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string loginUserId;
        private readonly string role;
        public AppointmentApiController(IAppointmentService appointmentService, IHttpContextAccessor httpContextAccessor)
        {
            _appointmentService = appointmentService;
            _httpContextAccessor = httpContextAccessor;
            loginUserId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            role = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Role);
        }
        [HttpPost]
        [Route("SaveCalendarData")]
        public IActionResult SaveCalendarData(AppointmentViewModel data)
        {
            CommonResponse<int> commonResponse = new CommonResponse<int>();
            try
            {
                commonResponse.Status = _appointmentService.AddUpdate(data).Result;
                if (commonResponse.Status == 1)
                {
                    // Succesfull update
                    commonResponse.Message = Helper.AppointmentUpdated;
                }
                if (commonResponse.Status == 2)
                {
                    // Succesfull addition
                    commonResponse.Message = Helper.AppointmentAdded;
                }
            }
            catch (Exception ex)
            {
                commonResponse.Message = ex.Message;
                commonResponse.Status = Helper.Failure_code;
            }
            return Ok(commonResponse);
        }
        [HttpGet]
        [Route("GetCalendarData")]
        public IActionResult GetCalendarData(string employeeId)
        {
            CommonResponse<List<AppointmentViewModel>> commonResponse = new CommonResponse<List<AppointmentViewModel>>();
            try
            {
                if (role == Helper.Customer)
                {
                    commonResponse.DataEnum = _appointmentService.CustomerAppointments(loginUserId);
                    commonResponse.Status = Helper.Succes_code;
                }
                else if (role == Helper.Employee)
                {
                    commonResponse.DataEnum = _appointmentService.EmployeeAppointments(loginUserId);
                    commonResponse.Status = Helper.Succes_code;
                }
                else
                {
                    commonResponse.DataEnum = _appointmentService.EmployeeAppointments(employeeId);
                    commonResponse.Status = Helper.Succes_code;
                }
            }
            catch (Exception ex)
            {
                commonResponse.Message = ex.Message;
                commonResponse.Status = Helper.Failure_code;
            }
            return Ok(commonResponse);
        }
        [HttpGet]
        [Route("GetCalendarDataById/{id}")]
        public IActionResult GetCalendarDataById(int id)
        {
            CommonResponse<AppointmentViewModel> commonResponse = new CommonResponse<AppointmentViewModel>();
            try
            {
                commonResponse.DataEnum = _appointmentService.GetById(id);
                commonResponse.Status = Helper.Succes_code;
            }
            catch (Exception ex)
            {
                commonResponse.Message = ex.Message;
                commonResponse.Status = Helper.Failure_code;
            }
            return Ok(commonResponse);
        }
        [HttpGet]
        [Route("ConfirmAppointment/{id}")]
        public IActionResult ConfirmAppointment(int id)
        {
            CommonResponse<AppointmentViewModel> commonResponse = new CommonResponse<AppointmentViewModel>();
            try
            {
                var result = _appointmentService.ConfirmAppointment(id).Result;
                if (result > 0)
                {
                    commonResponse.Status = Helper.Succes_code;
                    commonResponse.Message = Helper.AppointmentConfirmed;
                }
                else
                {
                    commonResponse.Status = Helper.Failure_code;
                    commonResponse.Message = Helper.AppointmentConfirmError;

                }
            }
            catch (Exception ex)
            {
                commonResponse.Message = ex.Message;
                commonResponse.Status = Helper.Failure_code;
            }
            return Ok(commonResponse);
        }

        [HttpGet]
        [Route("DeleteAppointment/{id}")]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            CommonResponse<AppointmentViewModel> commonResponse = new CommonResponse<AppointmentViewModel>();
            try
            {
                commonResponse.Status = await _appointmentService.DeleteAppointment(id);
                commonResponse.Message = commonResponse.Status == 1 ? Helper.AppointmentDeleted : Helper.SomethingWentWrong;
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
