using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webUniversity.Models;

namespace webUniversity.Controllers
{
    public class SpecialitiesController : Controller
    {
        private readonly UniversityContext _context;

        public SpecialitiesController(UniversityContext context)
        {
            _context = context;
        }

        // GET: Specialities
        public async Task<IActionResult> Index()
        {
              return _context.Specialitys != null ? 
                          View(await _context.Specialitys.ToListAsync()) :
                          Problem("Entity set 'UniversityContext.Specialitys'  is null.");
        }

        // GET: Specialities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Specialitys == null)
            {
                return NotFound();
            }

            var speciality = await _context.Specialitys
                .FirstOrDefaultAsync(m => m.specialityID == id);
            if (speciality == null)
            {
                return NotFound();
            }

            return View(speciality);
        }

        // GET: Specialities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Specialities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("specialityID,code,name,addName,specialityCode,largeGroup,branchScience")] Speciality speciality)
        {
            if (ModelState.IsValid)
            {
                _context.Add(speciality);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(speciality);
        }

        // GET: Specialities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Specialitys == null)
            {
                return NotFound();
            }

            var speciality = await _context.Specialitys.FindAsync(id);
            if (speciality == null)
            {
                return NotFound();
            }
            return View(speciality);
        }

        // POST: Specialities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("specialityID,code,name,addName,specialityCode,largeGroup,branchScience")] Speciality speciality)
        {
            if (id != speciality.specialityID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(speciality);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpecialityExists(speciality.specialityID))
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
            return View(speciality);
        }

        // GET: Specialities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Specialitys == null)
            {
                return NotFound();
            }

            var speciality = await _context.Specialitys
                .FirstOrDefaultAsync(m => m.specialityID == id);
            if (speciality == null)
            {
                return NotFound();
            }

            return View(speciality);
        }

        // POST: Specialities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_context.Specialitys == null)
            {
                return Problem("Entity set 'UniversityContext.Specialitys'  is null.");
            }
            var speciality = await _context.Specialitys.FindAsync(id);
            if (speciality != null)
            {
                _context.Specialitys.Remove(speciality);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpecialityExists(int? id)
        {
          return (_context.Specialitys?.Any(e => e.specialityID == id)).GetValueOrDefault();
        }
    }
}
