using CRYBZ_CCSB.Models;
using CRYBZ_CCSB.Models.ViewModels;
using CRYBZ_CCSB.Services;
using CRYBZ_CCSB.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRYBZ_CCSB.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        private readonly ApplicationDbContext _db;
        private const string ISO8601 = "yyyy-MM-ddTHH:mm:ss";
        public AppointmentController(IAppointmentService appointmentService, ApplicationDbContext _db
            )
        {

            _appointmentService = appointmentService;
        }
        public IActionResult Index()
        {
            ViewBag.EmployeeList = _appointmentService.GetEmployeeList();
            ViewBag.CustomerList = _appointmentService.GetCustomerList();
            ViewBag.Duration = Helper.GetTimeDropDown();
            return View();
        }
        [HttpGet]
        public IEnumerable<CalanderViewModel> GetAppointments()
        {
            var appointments = _db.Appointments.ToList();
            

            var apps = new List<CalanderViewModel>();
            foreach (var appointment in appointments)
            {
                apps.Add(new CalanderViewModel()
                {
                    id = appointment.Id,
                    start = appointment.StartDate.ToString(ISO8601),
                    end = appointment.StartDate.AddMinutes(30).ToString(ISO8601),
                    title = appointment.Title,
                    Type = appointment.Title
                });
            }
            //apps.Add(new CalanderViewModel() { title = "test", start = DateTime.UtcNow.ToString(ISO8601), end = DateTime.UtcNow.AddMinutes(30).ToString(ISO8601), id = 011 });
            return apps.ToArray();
        }
    }
}
