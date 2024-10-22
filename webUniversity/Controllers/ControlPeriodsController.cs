using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using webUniversity.Models;

namespace webUniversity.Controllers
{
    public class ControlPeriodsController : Controller
    {
        private readonly UniversityContext _context;

        public ControlPeriodsController(UniversityContext context)
        {
            _context = context;
        }

        // GET: ControlPeriods
        public async Task<IActionResult> Index()
        {
              return _context.ControlPeriods != null ? 
                          View(await _context.ControlPeriods.ToListAsync()) :
                          Problem("Entity set 'UniversityContext.ControlPeriods'  is null.");
        }

        // GET: ControlPeriods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ControlPeriods == null)
            {
                return NotFound();
            }

            var controlPeriod = await _context.ControlPeriods
                .FirstOrDefaultAsync(m => m.controlPeriodID == id);
            if (controlPeriod == null)
            {
                return NotFound();
            }

            return View(controlPeriod);
        }

        // GET: ControlPeriods/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ControlPeriods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("controlPeriodID,code,name,index")] ControlPeriod controlPeriod)
        {
            if (ModelState.IsValid)
            {
                _context.Add(controlPeriod);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(controlPeriod);
        }

        // GET: ControlPeriods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ControlPeriods == null)
            {
                return NotFound();
            }

            var controlPeriod = await _context.ControlPeriods.FindAsync(id);
            if (controlPeriod == null)
            {
                return NotFound();
            }
            return View(controlPeriod);
        }

        // POST: ControlPeriods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("controlPeriodID,code,name,index")] ControlPeriod controlPeriod)
        {
            if (id != controlPeriod.controlPeriodID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(controlPeriod);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ControlPeriodExists(controlPeriod.controlPeriodID))
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
            return View(controlPeriod);
        }

        // GET: ControlPeriods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ControlPeriods == null)
            {
                return NotFound();
            }

            var controlPeriod = await _context.ControlPeriods
                .FirstOrDefaultAsync(m => m.controlPeriodID == id);
            if (controlPeriod == null)
            {
                return NotFound();
            }

            return View(controlPeriod);
        }

        // POST: ControlPeriods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_context.ControlPeriods == null)
            {
                return Problem("Entity set 'UniversityContext.ControlPeriods'  is null.");
            }
            var controlPeriod = await _context.ControlPeriods.FindAsync(id);
            if (controlPeriod != null)
            {
                _context.ControlPeriods.Remove(controlPeriod);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ControlPeriodExists(int? id)
        {
          return (_context.ControlPeriods?.Any(e => e.controlPeriodID == id)).GetValueOrDefault();
        }
    }
}
