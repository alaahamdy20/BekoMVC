using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BekoMVC.Models;

namespace BekoMVC.Controllers
{
    public class VendorController : Controller
    {
        private readonly FinalProjectContext _context = new FinalProjectContext();

        /*public VendorController(FinalProjectContext context)
        {
            _context = context;
        }*/

        // GET: Vendor
        public async Task<IActionResult> Index()
        {
            var finalProjectContext = _context.Vendors.Include(v => v.AdminUsernameNavigation).Include(v => v.UsernameNavigation);
            return View(await finalProjectContext.ToListAsync());
        }

        // GET: Vendor/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendor = await _context.Vendors
                .Include(v => v.AdminUsernameNavigation)
                .Include(v => v.UsernameNavigation)
                .FirstOrDefaultAsync(m => m.Username == id);
            if (vendor == null)
            {
                return NotFound();
            }

            return View(vendor);
        }

        // GET: Vendor/Create
        public IActionResult Create()
        {
            ViewData["AdminUsername"] = new SelectList(_context.Admins, "Username", "Username");
            ViewData["Username"] = new SelectList(_context.Users, "Username", "Username");
            return View();
        }

        // POST: Vendor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Username,Activated,CompanyName,BankAccNo,AdminUsername")] Vendor vendor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vendor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdminUsername"] = new SelectList(_context.Admins, "Username", "Username", vendor.AdminUsername);
            ViewData["Username"] = new SelectList(_context.Users, "Username", "Username", vendor.Username);
            return View(vendor);
        }

        // GET: Vendor/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendor = await _context.Vendors.FindAsync(id);
            if (vendor == null)
            {
                return NotFound();
            }
            ViewData["AdminUsername"] = new SelectList(_context.Admins, "Username", "Username", vendor.AdminUsername);
            ViewData["Username"] = new SelectList(_context.Users, "Username", "Username", vendor.Username);
            return View(vendor);
        }

        // POST: Vendor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Username,Activated,CompanyName,BankAccNo,AdminUsername")] Vendor vendor)
        {
            if (id != vendor.Username)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vendor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendorExists(vendor.Username))
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
            ViewData["AdminUsername"] = new SelectList(_context.Admins, "Username", "Username", vendor.AdminUsername);
            ViewData["Username"] = new SelectList(_context.Users, "Username", "Username", vendor.Username);
            return View(vendor);
        }

        // GET: Vendor/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendor = await _context.Vendors
                .Include(v => v.AdminUsernameNavigation)
                .Include(v => v.UsernameNavigation)
                .FirstOrDefaultAsync(m => m.Username == id);
            if (vendor == null)
            {
                return NotFound();
            }

            return View(vendor);
        }

        // POST: Vendor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var vendor = await _context.Vendors.FindAsync(id);
            _context.Vendors.Remove(vendor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VendorExists(string id)
        {
            return _context.Vendors.Any(e => e.Username == id);
        }
    }
}
