using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RASS_System.Context;
using RASS_System.Models;

namespace RASS_System.Controllers
{
    public class DriverDatasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DriverDatasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DriverDatas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Drivers.Include(d => d.Vehicle);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DriverDatas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Drivers == null)
            {
                return NotFound();
            }

            var driverData = await _context.Drivers
                .Include(d => d.Vehicle)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (driverData == null)
            {
                return NotFound();
            }

            return View(driverData);
        }

        // GET: DriverDatas/Create
        public IActionResult Create()
        {
            ViewData["VehicleID"] = new SelectList(_context.Vehicles, "Id", "Id");
            return View();
        }

        // POST: DriverDatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Gender,Age,Contact,LicenseNumber,MedicalInfo,AccidentID,VehicleID")] DriverData driverData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(driverData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VehicleID"] = new SelectList(_context.Vehicles, "Id", "Id", driverData.VehicleID);
            return View(driverData);
        }

        // GET: DriverDatas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Drivers == null)
            {
                return NotFound();
            }

            var driverData = await _context.Drivers.FindAsync(id);
            if (driverData == null)
            {
                return NotFound();
            }
            ViewData["VehicleID"] = new SelectList(_context.Vehicles, "Id", "Id", driverData.VehicleID);
            return View(driverData);
        }

        // POST: DriverDatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Gender,Age,Contact,LicenseNumber,MedicalInfo,AccidentID,VehicleID")] DriverData driverData)
        {
            if (id != driverData.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(driverData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DriverDataExists(driverData.ID))
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
            ViewData["VehicleID"] = new SelectList(_context.Vehicles, "Id", "Id", driverData.VehicleID);
            return View(driverData);
        }

        // GET: DriverDatas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Drivers == null)
            {
                return NotFound();
            }

            var driverData = await _context.Drivers
                .Include(d => d.Vehicle)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (driverData == null)
            {
                return NotFound();
            }

            return View(driverData);
        }

        // POST: DriverDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Drivers == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Drivers'  is null.");
            }
            var driverData = await _context.Drivers.FindAsync(id);
            if (driverData != null)
            {
                _context.Drivers.Remove(driverData);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DriverDataExists(int id)
        {
          return (_context.Drivers?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
