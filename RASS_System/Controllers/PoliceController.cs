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
    public class PoliceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PoliceController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Police
        public async Task<IActionResult> Index()
        {
              return _context.Polices != null ? 
                          View(await _context.Polices.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Polices'  is null.");
        }

        // GET: Police/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Polices == null)
            {
                return NotFound();
            }

            var police = await _context.Polices
                .FirstOrDefaultAsync(m => m.Id == id);
            if (police == null)
            {
                return NotFound();
            }

            return View(police);
        }

        // GET: Police/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Police/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Rank,BadgeNumber,PhoneNo")] Police police)
        {
            if (ModelState.IsValid)
            {
                _context.Add(police);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(police);
        }

        // GET: Police/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Polices == null)
            {
                return NotFound();
            }

            var police = await _context.Polices.FindAsync(id);
            if (police == null)
            {
                return NotFound();
            }
            return View(police);
        }

        // POST: Police/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Rank,BadgeNumber,PhoneNo")] Police police)
        {
            if (id != police.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(police);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PoliceExists(police.Id))
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
            return View(police);
        }

        // GET: Police/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Polices == null)
            {
                return NotFound();
            }

            var police = await _context.Polices
                .FirstOrDefaultAsync(m => m.Id == id);
            if (police == null)
            {
                return NotFound();
            }

            return View(police);
        }

        // POST: Police/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Polices == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Polices'  is null.");
            }
            var police = await _context.Polices.FindAsync(id);
            if (police != null)
            {
                _context.Polices.Remove(police);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PoliceExists(int id)
        {
          return (_context.Polices?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
