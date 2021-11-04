using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRYBZ_CCSB.Models;
using CRYBZ_CCSB.Models.ViewModels;

namespace CRYBZ_CCSB.Controllers
{
    public class ContractController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContractController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Contract
        public async Task<IActionResult> Index()
        {
            return View(await _context.Contracts.ToListAsync());
        }

        // GET: Contract/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contractViewModel = await _context.Contracts
                .FirstOrDefaultAsync(m => m.ContractID == id);
            if (contractViewModel == null)
            {
                return NotFound();
            }

            return View(contractViewModel);
        }

        // GET: Contract/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contract/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContractID,StartDate,EndDate,CustomerId,LicencePlate")] ContractViewModel contractViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contractViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contractViewModel);
        }

        // GET: Contract/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contractViewModel = await _context.Contracts.FindAsync(id);
            if (contractViewModel == null)
            {
                return NotFound();
            }
            return View(contractViewModel);
        }

        // POST: Contract/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContractID,StartDate,EndDate,CustomerId,LicencePlate")] ContractViewModel contractViewModel)
        {
            if (id != contractViewModel.ContractID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contractViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContractViewModelExists(contractViewModel.ContractID))
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
            return View(contractViewModel);
        }

        // GET: Contract/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contractViewModel = await _context.Contracts
                .FirstOrDefaultAsync(m => m.ContractID == id);
            if (contractViewModel == null)
            {
                return NotFound();
            }

            return View(contractViewModel);
        }

        // POST: Contract/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contractViewModel = await _context.Contracts.FindAsync(id);
            _context.Contracts.Remove(contractViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContractViewModelExists(int id)
        {
            return _context.Contracts.Any(e => e.ContractID == id);
        }
    }
}
