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
    public class accidentDatasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public accidentDatasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: accidentDatas
        public async Task<IActionResult> Index()
        {
            return _context.accidentDatas != null ?
                        View(await _context.accidentDatas.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.accidentDatas'  is null.");
        }

        // GET: accidentDatas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.accidentDatas == null)
            {
                return NotFound();
            }

            var accidentData = await _context.accidentDatas
                .FirstOrDefaultAsync(m => m.ID == id);
            if (accidentData == null)
            {
                return NotFound();
            }

            return View(accidentData);
        }

        // GET: accidentDatas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: accidentDatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,lastUpdated,subBase,county,road,place,severity,description,weather,hospitalID,policeID")] accidentData accidentData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accidentData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(accidentData);
        }

        // GET: accidentDatas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.accidentDatas == null)
            {
                return NotFound();
            }

            var accidentData = await _context.accidentDatas.FindAsync(id);
            if (accidentData == null)
            {
                return NotFound();
            }
            return View(accidentData);
        }

        // POST: accidentDatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,lastUpdated,subBase,county,road,place,severity,description,weather,hospitalID,policeID")] accidentData accidentData)
        {
            if (id != accidentData.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accidentData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!accidentDataExists(accidentData.ID))
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
            return View(accidentData);
        }

        // GET: accidentDatas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.accidentDatas == null)
            {
                return NotFound();
            }

            var accidentData = await _context.accidentDatas
                .FirstOrDefaultAsync(m => m.ID == id);
            if (accidentData == null)
            {
                return NotFound();
            }

            return View(accidentData);
        }

        // POST: accidentDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.accidentDatas == null)
            {
                return Problem("Entity set 'ApplicationDbContext.accidentDatas'  is null.");
            }
            var accidentData = await _context.accidentDatas.FindAsync(id);
            if (accidentData != null)
            {
                _context.accidentDatas.Remove(accidentData);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool accidentDataExists(int id)
        {
            return (_context.accidentDatas?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
