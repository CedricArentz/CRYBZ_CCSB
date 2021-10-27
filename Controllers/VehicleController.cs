using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRYBZ_CCSB.Models;
using CRYBZ_CCSB.Models.ViewModels;
using CRYBZ_CCSB.Services;

namespace CRYBZ_CCSB.Controllers
{
    public class VehicleController : Controller
    {
        private readonly ApplicationDbContext _context;
        IAppointmentService _appointmentService;

        public VehicleController(ApplicationDbContext context, IAppointmentService appointmentService)
        {
            _context = context;
            _appointmentService = appointmentService;
        }

        // GET: Vehicle
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vehicles.ToListAsync());
        }

        // GET: Vehicle/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleViewModel = await _context.Vehicles
                .FirstOrDefaultAsync(m => m.LicencePlate == id);
            if (vehicleViewModel == null)
            {
                return NotFound();
            }

            return View(vehicleViewModel);
        }

        // GET: Vehicle/Create
        public IActionResult Create()
        {
            ViewBag.CustomerList =  _appointmentService.GetCustomerList();
            return View();
        }

        // POST: Vehicle/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LicencePlate,VehicleType,Length,Brand,Type,CustomerId")] VehicleViewModel vehicleViewModel)
        {
            if (ModelState.IsValid)
            {
                if (vehicleViewModel.Brand != null)
                {

                }
                _context.Add(vehicleViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehicleViewModel);
        }

        // GET: Vehicle/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleViewModel = await _context.Vehicles.FindAsync(id);
            if (vehicleViewModel == null)
            {
                return NotFound();
            }
            return View(vehicleViewModel);
        }

        // POST: Vehicle/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("LicencePlate,VehicleType,Length,Brand,Type,CustomerId")] VehicleViewModel vehicleViewModel)
        {
            if (id != vehicleViewModel.LicencePlate)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicleViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleExists(vehicleViewModel.LicencePlate))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(vehicleViewModel);
        }

        // GET: Vehicle/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleViewModel = await _context.Vehicles
                .FirstOrDefaultAsync(m => m.LicencePlate == id);
            if (vehicleViewModel == null)
            {
                return NotFound();
            }

            return View(vehicleViewModel);
        }

        // POST: Vehicle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var vehicleViewModel = await _context.Vehicles.FindAsync(id);
            _context.Vehicles.Remove(vehicleViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleExists(string id)
        {
            return _context.Vehicles.Any(e => e.LicencePlate == id);
        }
    }
}
