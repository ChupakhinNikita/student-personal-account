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
    public class StatementsController : Controller
    {
        private readonly UniversityContext _context;

        public StatementsController(UniversityContext context)
        {
            _context = context;
        }

        // GET: Statements
        public async Task<IActionResult> Index()
        {
            var universityContext = _context.Statements.Include(s => s.ControlForm).Include(s => s.ControlPeriod).Include(s => s.Discipline).Include(s => s.Mark).Include(s => s.Professor).Include(s => s.StatementType).Include(s => s.Student);
            return View(await universityContext.ToListAsync());
        }

        // GET: Statements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Statements == null)
            {
                return NotFound();
            }

            var statement = await _context.Statements
                .Include(s => s.ControlForm)
                .Include(s => s.ControlPeriod)
                .Include(s => s.Discipline)
                .Include(s => s.Mark)
                .Include(s => s.Professor)
                .Include(s => s.StatementType)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.statementID == id);
            if (statement == null)
            {
                return NotFound();
            }

            return View(statement);
        }

        // GET: Statements/Create
        public IActionResult Create()
        {
            ViewData["controlFormID"] = new SelectList(_context.ControlForms, "controlFormID", "controlFormID");
            ViewData["controlPeriodID"] = new SelectList(_context.ControlPeriods, "controlPeriodID", "controlPeriodID");
            ViewData["disciplineID"] = new SelectList(_context.Disciplines, "disciplineID", "disciplineID");
            ViewData["markID"] = new SelectList(_context.Marks, "markID", "markID");
            ViewData["professorID"] = new SelectList(_context.Professors, "professorID", "professorID");
            ViewData["statementTypeID"] = new SelectList(_context.StatementTypes, "statementTypeID", "statementTypeID");
            ViewData["studentID"] = new SelectList(_context.Students, "studentID", "studentID");
            return View();
        }

        // POST: Statements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("statementID,code,date,timeStart,timeEnd,isIndividual,statementTypeID,controlFormID,disciplineID,controlPeriodID,markID,professorID,studentID")] Statement statement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(statement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["controlFormID"] = new SelectList(_context.ControlForms, "controlFormID", "controlFormID", statement.controlFormID);
            ViewData["controlPeriodID"] = new SelectList(_context.ControlPeriods, "controlPeriodID", "controlPeriodID", statement.controlPeriodID);
            ViewData["disciplineID"] = new SelectList(_context.Disciplines, "disciplineID", "disciplineID", statement.disciplineID);
            ViewData["markID"] = new SelectList(_context.Marks, "markID", "markID", statement.markID);
            ViewData["professorID"] = new SelectList(_context.Professors, "professorID", "professorID", statement.professorID);
            ViewData["statementTypeID"] = new SelectList(_context.StatementTypes, "statementTypeID", "statementTypeID", statement.statementTypeID);
            ViewData["studentID"] = new SelectList(_context.Students, "studentID", "studentID", statement.studentID);
            return View(statement);
        }

        // GET: Statements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Statements == null)
            {
                return NotFound();
            }

            var statement = await _context.Statements.FindAsync(id);
            if (statement == null)
            {
                return NotFound();
            }
            ViewData["controlFormID"] = new SelectList(_context.ControlForms, "controlFormID", "controlFormID", statement.controlFormID);
            ViewData["controlPeriodID"] = new SelectList(_context.ControlPeriods, "controlPeriodID", "controlPeriodID", statement.controlPeriodID);
            ViewData["disciplineID"] = new SelectList(_context.Disciplines, "disciplineID", "disciplineID", statement.disciplineID);
            ViewData["markID"] = new SelectList(_context.Marks, "markID", "markID", statement.markID);
            ViewData["professorID"] = new SelectList(_context.Professors, "professorID", "professorID", statement.professorID);
            ViewData["statementTypeID"] = new SelectList(_context.StatementTypes, "statementTypeID", "statementTypeID", statement.statementTypeID);
            ViewData["studentID"] = new SelectList(_context.Students, "studentID", "studentID", statement.studentID);
            return View(statement);
        }

        // POST: Statements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("statementID,code,date,timeStart,timeEnd,isIndividual,statementTypeID,controlFormID,disciplineID,controlPeriodID,markID,professorID,studentID")] Statement statement)
        {
            if (id != statement.statementID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(statement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatementExists(statement.statementID))
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
            ViewData["controlFormID"] = new SelectList(_context.ControlForms, "controlFormID", "controlFormID", statement.controlFormID);
            ViewData["controlPeriodID"] = new SelectList(_context.ControlPeriods, "controlPeriodID", "controlPeriodID", statement.controlPeriodID);
            ViewData["disciplineID"] = new SelectList(_context.Disciplines, "disciplineID", "disciplineID", statement.disciplineID);
            ViewData["markID"] = new SelectList(_context.Marks, "markID", "markID", statement.markID);
            ViewData["professorID"] = new SelectList(_context.Professors, "professorID", "professorID", statement.professorID);
            ViewData["statementTypeID"] = new SelectList(_context.StatementTypes, "statementTypeID", "statementTypeID", statement.statementTypeID);
            ViewData["studentID"] = new SelectList(_context.Students, "studentID", "studentID", statement.studentID);
            return View(statement);
        }

        // GET: Statements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Statements == null)
            {
                return NotFound();
            }

            var statement = await _context.Statements
                .Include(s => s.ControlForm)
                .Include(s => s.ControlPeriod)
                .Include(s => s.Discipline)
                .Include(s => s.Mark)
                .Include(s => s.Professor)
                .Include(s => s.StatementType)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.statementID == id);
            if (statement == null)
            {
                return NotFound();
            }

            return View(statement);
        }

        // POST: Statements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_context.Statements == null)
            {
                return Problem("Entity set 'UniversityContext.Statements'  is null.");
            }
            var statement = await _context.Statements.FindAsync(id);
            if (statement != null)
            {
                _context.Statements.Remove(statement);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StatementExists(int? id)
        {
          return (_context.Statements?.Any(e => e.statementID == id)).GetValueOrDefault();
        }
    }
}
