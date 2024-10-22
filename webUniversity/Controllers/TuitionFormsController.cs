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
    public class TuitionFormsController : Controller
    {
        private readonly UniversityContext _context;

        public TuitionFormsController(UniversityContext context)
        {
            _context = context;
        }

        // GET: TuitionForms
        public async Task<IActionResult> Index()
        {
              return _context.TuitionForms != null ? 
                          View(await _context.TuitionForms.ToListAsync()) :
                          Problem("Entity set 'UniversityContext.TuitionForms'  is null.");
        }

        // GET: TuitionForms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TuitionForms == null)
            {
                return NotFound();
            }

            var tuitionForm = await _context.TuitionForms
                .FirstOrDefaultAsync(m => m.tuitionFormlID == id);
            if (tuitionForm == null)
            {
                return NotFound();
            }

            return View(tuitionForm);
        }

        // GET: TuitionForms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TuitionForms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("tuitionFormlID,code,name,addName")] TuitionForm tuitionForm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tuitionForm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tuitionForm);
        }

        // GET: TuitionForms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TuitionForms == null)
            {
                return NotFound();
            }

            var tuitionForm = await _context.TuitionForms.FindAsync(id);
            if (tuitionForm == null)
            {
                return NotFound();
            }
            return View(tuitionForm);
        }

        // POST: TuitionForms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("tuitionFormlID,code,name,addName")] TuitionForm tuitionForm)
        {
            if (id != tuitionForm.tuitionFormlID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tuitionForm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TuitionFormExists(tuitionForm.tuitionFormlID))
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
            return View(tuitionForm);
        }

        // GET: TuitionForms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TuitionForms == null)
            {
                return NotFound();
            }

            var tuitionForm = await _context.TuitionForms
                .FirstOrDefaultAsync(m => m.tuitionFormlID == id);
            if (tuitionForm == null)
            {
                return NotFound();
            }

            return View(tuitionForm);
        }

        // POST: TuitionForms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_context.TuitionForms == null)
            {
                return Problem("Entity set 'UniversityContext.TuitionForms'  is null.");
            }
            var tuitionForm = await _context.TuitionForms.FindAsync(id);
            if (tuitionForm != null)
            {
                _context.TuitionForms.Remove(tuitionForm);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TuitionFormExists(int? id)
        {
          return (_context.TuitionForms?.Any(e => e.tuitionFormlID == id)).GetValueOrDefault();
        }
    }
}
