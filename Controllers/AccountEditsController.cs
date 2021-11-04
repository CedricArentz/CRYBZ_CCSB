using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRYBZ_CCSB.Models;

namespace CRYBZ_CCSB.Controllers
{
    public class AccountEditsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountEditsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AccountEdits
        public async Task<IActionResult> Index()
        {
            return View(await _context.AccountEdit.ToListAsync());
        }

        // GET: AccountEdits/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountEdit = await _context.AccountEdit
                .FirstOrDefaultAsync(m => m.AccountID == id);
            if (accountEdit == null)
            {
                return NotFound();
            }

            return View(accountEdit);
        }

        // GET: AccountEdits/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AccountEdits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AccountID,FirstName,MiddleName,LastName")] AccountEdit accountEdit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accountEdit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(accountEdit);
        }

        // GET: AccountEdits/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountEdit = await _context.AccountEdit.FindAsync(id);
            if (accountEdit == null)
            {
                return NotFound();
            }
            return View(accountEdit);
        }

        // POST: AccountEdits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("AccountID,FirstName,MiddleName,LastName")] AccountEdit accountEdit)
        {
            if (id != accountEdit.AccountID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accountEdit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountEditExists(accountEdit.AccountID))
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
            return View(accountEdit);
        }

        // GET: AccountEdits/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountEdit = await _context.AccountEdit
                .FirstOrDefaultAsync(m => m.AccountID == id);
            if (accountEdit == null)
            {
                return NotFound();
            }

            return View(accountEdit);
        }

        // POST: AccountEdits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var accountEdit = await _context.AccountEdit.FindAsync(id);
            _context.AccountEdit.Remove(accountEdit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountEditExists(string id)
        {
            return _context.AccountEdit.Any(e => e.AccountID == id);
        }
    }
}
