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
    public class StudentsController : Controller
    {
        private readonly UniversityContext _context;

        public StudentsController(UniversityContext context)
        {
            _context = context;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            var universityContext = _context.Students.Include(s => s.Course).Include(s => s.Faculty).Include(s => s.Group).Include(s => s.Speciality).Include(s => s.Specialization).Include(s => s.StudentStatus).Include(s => s.TrainingLevel).Include(s => s.TuitionForm).Include(s => s.TuitionType).Include(s => s.User);
            return View(await universityContext.ToListAsync());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .Include(s => s.Course)
                .Include(s => s.Faculty)
                .Include(s => s.Group)
                .Include(s => s.Speciality)
                .Include(s => s.Specialization)
                .Include(s => s.StudentStatus)
                .Include(s => s.TrainingLevel)
                .Include(s => s.TuitionForm)
                .Include(s => s.TuitionType)
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.studentID == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            ViewData["courseID"] = new SelectList(_context.Courses, "courseID", "courseID");
            ViewData["facultyID"] = new SelectList(_context.Facultys, "facultyID", "facultyID");
            ViewData["groupID"] = new SelectList(_context.Groups, "groupID", "groupID");
            ViewData["specialityID"] = new SelectList(_context.Specialitys, "specialityID", "specialityID");
            ViewData["specializationID"] = new SelectList(_context.Specializations, "specializationID", "specializationID");
            ViewData["studentStatusID"] = new SelectList(_context.StudentStatuss, "studentStatusTypeID", "studentStatusTypeID");
            ViewData["trainingLevelID"] = new SelectList(_context.TrainingLevels, "trainingLevelID", "trainingLevelID");
            ViewData["tuitionFormID"] = new SelectList(_context.TuitionForms, "tuitionFormlID", "tuitionFormlID");
            ViewData["tuitionTypeID"] = new SelectList(_context.TuitionTypes, "tuitionTypelID", "tuitionTypelID");
            ViewData["userID"] = new SelectList(_context.Users, "userID", "userID");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("studentID,code,gradebook,lastName,firstName,patronomic,groupID,tuitionTypeID,tuitionFormID,trainingLevelID,studentStatusID,specialityID,specializationID,courseID,userID,facultyID")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["courseID"] = new SelectList(_context.Courses, "courseID", "courseID", student.courseID);
            ViewData["facultyID"] = new SelectList(_context.Facultys, "facultyID", "facultyID", student.facultyID);
            ViewData["groupID"] = new SelectList(_context.Groups, "groupID", "groupID", student.groupID);
            ViewData["specialityID"] = new SelectList(_context.Specialitys, "specialityID", "specialityID", student.specialityID);
            ViewData["specializationID"] = new SelectList(_context.Specializations, "specializationID", "specializationID", student.specializationID);
            ViewData["studentStatusID"] = new SelectList(_context.StudentStatuss, "studentStatusTypeID", "studentStatusTypeID", student.studentStatusID);
            ViewData["trainingLevelID"] = new SelectList(_context.TrainingLevels, "trainingLevelID", "trainingLevelID", student.trainingLevelID);
            ViewData["tuitionFormID"] = new SelectList(_context.TuitionForms, "tuitionFormlID", "tuitionFormlID", student.tuitionFormID);
            ViewData["tuitionTypeID"] = new SelectList(_context.TuitionTypes, "tuitionTypelID", "tuitionTypelID", student.tuitionTypeID);
            ViewData["userID"] = new SelectList(_context.Users, "userID", "userID", student.userID);
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            ViewData["courseID"] = new SelectList(_context.Courses, "courseID", "courseID", student.courseID);
            ViewData["facultyID"] = new SelectList(_context.Facultys, "facultyID", "facultyID", student.facultyID);
            ViewData["groupID"] = new SelectList(_context.Groups, "groupID", "groupID", student.groupID);
            ViewData["specialityID"] = new SelectList(_context.Specialitys, "specialityID", "specialityID", student.specialityID);
            ViewData["specializationID"] = new SelectList(_context.Specializations, "specializationID", "specializationID", student.specializationID);
            ViewData["studentStatusID"] = new SelectList(_context.StudentStatuss, "studentStatusTypeID", "studentStatusTypeID", student.studentStatusID);
            ViewData["trainingLevelID"] = new SelectList(_context.TrainingLevels, "trainingLevelID", "trainingLevelID", student.trainingLevelID);
            ViewData["tuitionFormID"] = new SelectList(_context.TuitionForms, "tuitionFormlID", "tuitionFormlID", student.tuitionFormID);
            ViewData["tuitionTypeID"] = new SelectList(_context.TuitionTypes, "tuitionTypelID", "tuitionTypelID", student.tuitionTypeID);
            ViewData["userID"] = new SelectList(_context.Users, "userID", "userID", student.userID);
            return View(student);
        }

        // POST: Students/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("studentID,code,gradebook,lastName,firstName,patronomic,groupID,tuitionTypeID,tuitionFormID,trainingLevelID,studentStatusID,specialityID,specializationID,courseID,userID,facultyID")] Student student)
        {
            if (id != student.studentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.studentID))
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
            ViewData["courseID"] = new SelectList(_context.Courses, "courseID", "courseID", student.courseID);
            ViewData["facultyID"] = new SelectList(_context.Facultys, "facultyID", "facultyID", student.facultyID);
            ViewData["groupID"] = new SelectList(_context.Groups, "groupID", "groupID", student.groupID);
            ViewData["specialityID"] = new SelectList(_context.Specialitys, "specialityID", "specialityID", student.specialityID);
            ViewData["specializationID"] = new SelectList(_context.Specializations, "specializationID", "specializationID", student.specializationID);
            ViewData["studentStatusID"] = new SelectList(_context.StudentStatuss, "studentStatusTypeID", "studentStatusTypeID", student.studentStatusID);
            ViewData["trainingLevelID"] = new SelectList(_context.TrainingLevels, "trainingLevelID", "trainingLevelID", student.trainingLevelID);
            ViewData["tuitionFormID"] = new SelectList(_context.TuitionForms, "tuitionFormlID", "tuitionFormlID", student.tuitionFormID);
            ViewData["tuitionTypeID"] = new SelectList(_context.TuitionTypes, "tuitionTypelID", "tuitionTypelID", student.tuitionTypeID);
            ViewData["userID"] = new SelectList(_context.Users, "userID", "userID", student.userID);
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .Include(s => s.Course)
                .Include(s => s.Faculty)
                .Include(s => s.Group)
                .Include(s => s.Speciality)
                .Include(s => s.Specialization)
                .Include(s => s.StudentStatus)
                .Include(s => s.TrainingLevel)
                .Include(s => s.TuitionForm)
                .Include(s => s.TuitionType)
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.studentID == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_context.Students == null)
            {
                return Problem("Entity set 'UniversityContext.Students'  is null.");
            }
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int? id)
        {
          return (_context.Students?.Any(e => e.studentID == id)).GetValueOrDefault();
        }
    }
}
