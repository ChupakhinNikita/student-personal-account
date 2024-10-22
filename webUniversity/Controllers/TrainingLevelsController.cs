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
    public class TrainingLevelsController : Controller
    {
        private readonly UniversityContext _context;

        public TrainingLevelsController(UniversityContext context)
        {
            _context = context;
        }

        // GET: TrainingLevels
        public async Task<IActionResult> Index()
        {
              return _context.TrainingLevels != null ? 
                          View(await _context.TrainingLevels.ToListAsync()) :
                          Problem("Entity set 'UniversityContext.TrainingLevels'  is null.");
        }

        // GET: TrainingLevels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TrainingLevels == null)
            {
                return NotFound();
            }

            var trainingLevel = await _context.TrainingLevels
                .FirstOrDefaultAsync(m => m.trainingLevelID == id);
            if (trainingLevel == null)
            {
                return NotFound();
            }

            return View(trainingLevel);
        }

        // GET: TrainingLevels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TrainingLevels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("trainingLevelID,code,name,addName")] TrainingLevel trainingLevel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trainingLevel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trainingLevel);
        }

        // GET: TrainingLevels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TrainingLevels == null)
            {
                return NotFound();
            }

            var trainingLevel = await _context.TrainingLevels.FindAsync(id);
            if (trainingLevel == null)
            {
                return NotFound();
            }
            return View(trainingLevel);
        }

        // POST: TrainingLevels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("trainingLevelID,code,name,addName")] TrainingLevel trainingLevel)
        {
            if (id != trainingLevel.trainingLevelID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trainingLevel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrainingLevelExists(trainingLevel.trainingLevelID))
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
            return View(trainingLevel);
        }

        // GET: TrainingLevels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TrainingLevels == null)
            {
                return NotFound();
            }

            var trainingLevel = await _context.TrainingLevels
                .FirstOrDefaultAsync(m => m.trainingLevelID == id);
            if (trainingLevel == null)
            {
                return NotFound();
            }

            return View(trainingLevel);
        }

        // POST: TrainingLevels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_context.TrainingLevels == null)
            {
                return Problem("Entity set 'UniversityContext.TrainingLevels'  is null.");
            }
            var trainingLevel = await _context.TrainingLevels.FindAsync(id);
            if (trainingLevel != null)
            {
                _context.TrainingLevels.Remove(trainingLevel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrainingLevelExists(int? id)
        {
          return (_context.TrainingLevels?.Any(e => e.trainingLevelID == id)).GetValueOrDefault();
        }
    }
}
