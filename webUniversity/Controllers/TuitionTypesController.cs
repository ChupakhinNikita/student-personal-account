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
    public class TuitionTypesController : Controller
    {
        private readonly UniversityContext _context;

        public TuitionTypesController(UniversityContext context)
        {
            _context = context;
        }

        // GET: TuitionTypes
        public async Task<IActionResult> Index()
        {
              return _context.TuitionTypes != null ? 
                          View(await _context.TuitionTypes.ToListAsync()) :
                          Problem("Entity set 'UniversityContext.TuitionTypes'  is null.");
        }

        // GET: TuitionTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TuitionTypes == null)
            {
                return NotFound();
            }

            var tuitionType = await _context.TuitionTypes
                .FirstOrDefaultAsync(m => m.tuitionTypelID == id);
            if (tuitionType == null)
            {
                return NotFound();
            }

            return View(tuitionType);
        }

        // GET: TuitionTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TuitionTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("tuitionTypelID,code,name,addName")] TuitionType tuitionType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tuitionType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tuitionType);
        }

        // GET: TuitionTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TuitionTypes == null)
            {
                return NotFound();
            }

            var tuitionType = await _context.TuitionTypes.FindAsync(id);
            if (tuitionType == null)
            {
                return NotFound();
            }
            return View(tuitionType);
        }

        // POST: TuitionTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("tuitionTypelID,code,name,addName")] TuitionType tuitionType)
        {
            if (id != tuitionType.tuitionTypelID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tuitionType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TuitionTypeExists(tuitionType.tuitionTypelID))
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
            return View(tuitionType);
        }

        // GET: TuitionTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TuitionTypes == null)
            {
                return NotFound();
            }

            var tuitionType = await _context.TuitionTypes
                .FirstOrDefaultAsync(m => m.tuitionTypelID == id);
            if (tuitionType == null)
            {
                return NotFound();
            }

            return View(tuitionType);
        }

        // POST: TuitionTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_context.TuitionTypes == null)
            {
                return Problem("Entity set 'UniversityContext.TuitionTypes'  is null.");
            }
            var tuitionType = await _context.TuitionTypes.FindAsync(id);
            if (tuitionType != null)
            {
                _context.TuitionTypes.Remove(tuitionType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TuitionTypeExists(int? id)
        {
          return (_context.TuitionTypes?.Any(e => e.tuitionTypelID == id)).GetValueOrDefault();
        }
    }
}
