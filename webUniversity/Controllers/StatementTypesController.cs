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
    public class StatementTypesController : Controller
    {
        private readonly UniversityContext _context;

        public StatementTypesController(UniversityContext context)
        {
            _context = context;
        }

        // GET: StatementTypes
        public async Task<IActionResult> Index()
        {
              return _context.StatementTypes != null ? 
                          View(await _context.StatementTypes.ToListAsync()) :
                          Problem("Entity set 'UniversityContext.StatementTypes'  is null.");
        }

        // GET: StatementTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StatementTypes == null)
            {
                return NotFound();
            }

            var statementType = await _context.StatementTypes
                .FirstOrDefaultAsync(m => m.statementTypeID == id);
            if (statementType == null)
            {
                return NotFound();
            }

            return View(statementType);
        }

        // GET: StatementTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StatementTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("statementTypeID,code,name")] StatementType statementType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(statementType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(statementType);
        }

        // GET: StatementTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StatementTypes == null)
            {
                return NotFound();
            }

            var statementType = await _context.StatementTypes.FindAsync(id);
            if (statementType == null)
            {
                return NotFound();
            }
            return View(statementType);
        }

        // POST: StatementTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("statementTypeID,code,name")] StatementType statementType)
        {
            if (id != statementType.statementTypeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(statementType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatementTypeExists(statementType.statementTypeID))
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
            return View(statementType);
        }

        // GET: StatementTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StatementTypes == null)
            {
                return NotFound();
            }

            var statementType = await _context.StatementTypes
                .FirstOrDefaultAsync(m => m.statementTypeID == id);
            if (statementType == null)
            {
                return NotFound();
            }

            return View(statementType);
        }

        // POST: StatementTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_context.StatementTypes == null)
            {
                return Problem("Entity set 'UniversityContext.StatementTypes'  is null.");
            }
            var statementType = await _context.StatementTypes.FindAsync(id);
            if (statementType != null)
            {
                _context.StatementTypes.Remove(statementType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StatementTypeExists(int? id)
        {
          return (_context.StatementTypes?.Any(e => e.statementTypeID == id)).GetValueOrDefault();
        }
    }
}
