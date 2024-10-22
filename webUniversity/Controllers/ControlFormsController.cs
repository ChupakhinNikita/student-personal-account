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
    public class ControlFormsController : Controller
    {
        private readonly UniversityContext _context;

        public ControlFormsController(UniversityContext context)
        {
            _context = context;
        }

        // GET: ControlForms
        public async Task<IActionResult> Index()
        {
              return _context.ControlForms != null ? 
                          View(await _context.ControlForms.ToListAsync()) :
                          Problem("Entity set 'UniversityContext.ControlForms'  is null.");
        }

        // GET: ControlForms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ControlForms == null)
            {
                return NotFound();
            }

            var controlForm = await _context.ControlForms
                .FirstOrDefaultAsync(m => m.controlFormID == id);
            if (controlForm == null)
            {
                return NotFound();
            }

            return View(controlForm);
        }

        // GET: ControlForms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ControlForms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("controlFormID,code,name")] ControlForm controlForm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(controlForm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(controlForm);
        }

        // GET: ControlForms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ControlForms == null)
            {
                return NotFound();
            }

            var controlForm = await _context.ControlForms.FindAsync(id);
            if (controlForm == null)
            {
                return NotFound();
            }
            return View(controlForm);
        }

        // POST: ControlForms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("controlFormID,code,name")] ControlForm controlForm)
        {
            if (id != controlForm.controlFormID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(controlForm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ControlFormExists(controlForm.controlFormID))
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
            return View(controlForm);
        }

        // GET: ControlForms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ControlForms == null)
            {
                return NotFound();
            }

            var controlForm = await _context.ControlForms
                .FirstOrDefaultAsync(m => m.controlFormID == id);
            if (controlForm == null)
            {
                return NotFound();
            }

            return View(controlForm);
        }

        // POST: ControlForms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_context.ControlForms == null)
            {
                return Problem("Entity set 'UniversityContext.ControlForms'  is null.");
            }
            var controlForm = await _context.ControlForms.FindAsync(id);
            if (controlForm != null)
            {
                _context.ControlForms.Remove(controlForm);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ControlFormExists(int? id)
        {
          return (_context.ControlForms?.Any(e => e.controlFormID == id)).GetValueOrDefault();
        }
    }
}
