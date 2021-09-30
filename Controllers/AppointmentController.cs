using CRYBZ_CCSB.Services;
using CRYBZ_CCSB.Utility;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRYBZ_CCSB.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }
        public IActionResult Index()
        {
            ViewBag.DoctorList = _appointmentService.GetEmployeeList();
            ViewBag.PatientList = _appointmentService.GetCustomerList();
            ViewBag.Duration = Helper.GetTimeDropDown();
            return View();
        }
    }
}
