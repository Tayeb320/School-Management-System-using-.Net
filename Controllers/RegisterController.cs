using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolWeb.Models;

namespace SchoolWeb.Controllers
{
    public class RegisterController : Controller
    {
        private readonly DataContext _context;

        public RegisterController(DataContext context)
        {
            _context = context;
        }

            public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("AccountType") == "Register")
            {

                return View(await _context.Section.ToListAsync());

            }

            else
            {
                HttpContext.Session.Clear();

                return RedirectToAction("Login", "Login");
            }
        }

        // GET: Section/Details/5
        public async Task<IActionResult> SectionDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sections = await _context.Section
                .SingleOrDefaultAsync(m => m.Section_Id == id);
            if (sections == null)
            {
                return NotFound();
            }

            return View(sections);
        }

        // GET: Section/Create
        public IActionResult CreateSection()
        {
            if (HttpContext.Session.GetString("AccountType") == "Register")
            {

                return View();

            }

            else
            {
                HttpContext.Session.Clear();

                return RedirectToAction("Login", "Login");
            }
           
        }

        // POST: Section/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSection([Bind("Section_Id,Section_Name")] Sections sections)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sections);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sections);
        }

        // GET: Section/Edit/5
        public async Task<IActionResult> EditSection(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sections = await _context.Section.SingleOrDefaultAsync(m => m.Section_Id == id);
            if (sections == null)
            {
                return NotFound();
            }
            return View(sections);
        }

        // POST: Section/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditSection(int id, [Bind("Section_Id,Section_Name")] Sections sections)
        {
            if (id != sections.Section_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sections);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SectionsExists(sections.Section_Id))
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
            return View(sections);
        }

        // GET: Section/Delete/5
        public async Task<IActionResult> DeleteSection(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sections = await _context.Section
                .SingleOrDefaultAsync(m => m.Section_Id == id);
            if (sections == null)
            {
                return NotFound();
            }

            return View(sections);
        }

        // POST: Section/Delete/5
        [HttpPost, ActionName("DeleteSection")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteSectionConfirmed(int id)
        {
            var sections = await _context.Section.SingleOrDefaultAsync(m => m.Section_Id == id);
            _context.Section.Remove(sections);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SectionsExists(int id)
        {
            return _context.Section.Any(e => e.Section_Id == id);
        }

        // GET: ExamType
        public async Task<IActionResult> ExamIndex()
        {
            if (HttpContext.Session.GetString("AccountType") == "Register")
            {
                return View(await _context.ExamType.ToListAsync());
            }

            else
            {
                HttpContext.Session.Clear();

                return RedirectToAction("Login", "Login");
            }
        }

        // GET: ExamType/Details/5
        public async Task<IActionResult> ExamDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var examTypes = await _context.ExamType
                .SingleOrDefaultAsync(m => m.ExamType_Id == id);
            if (examTypes == null)
            {
                return NotFound();
            }

            return View(examTypes);
        }

        // GET: ExamType/Create
        public IActionResult CreateExam()
        {
            if (HttpContext.Session.GetString("AccountType") == "Register")
            {
                return View();
            }

            else
            {
                HttpContext.Session.Clear();

                return RedirectToAction("Login", "Login");
            }
           
        }

        // POST: ExamType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateExam([Bind("ExamType_Id,ExamType_Name")] ExamTypes examTypes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(examTypes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ExamIndex));
            }
            return View(examTypes);
        }

        // GET: ExamType/Edit/5
        public async Task<IActionResult> ExamEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var examTypes = await _context.ExamType.SingleOrDefaultAsync(m => m.ExamType_Id == id);
            if (examTypes == null)
            {
                return NotFound();
            }
            return View(examTypes);
        }

        // POST: ExamType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ExamEdit(int id, [Bind("ExamType_Id,ExamType_Name")] ExamTypes examTypes)
        {
            if (id != examTypes.ExamType_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(examTypes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExamTypesExists(examTypes.ExamType_Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ExamIndex));
            }
            return View(examTypes);
        }

        // GET: ExamType/Delete/5
        public async Task<IActionResult> DeleteExam(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var examTypes = await _context.ExamType
                .SingleOrDefaultAsync(m => m.ExamType_Id == id);
            if (examTypes == null)
            {
                return NotFound();
            }

            return View(examTypes);
        }

        // POST: ExamType/Delete/5
        [HttpPost, ActionName("DeleteExam")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteExamConfirmed(int id)
        {
            var examTypes = await _context.ExamType.SingleOrDefaultAsync(m => m.ExamType_Id == id);
            _context.ExamType.Remove(examTypes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ExamIndex));
        }

        private bool ExamTypesExists(int id)
        {
            return _context.ExamType.Any(e => e.ExamType_Id == id);
        }

        // GET: Subject
        public async Task<IActionResult> SubjectIndex()
        {
            if (HttpContext.Session.GetString("AccountType") == "Register")
            {
                return View(await _context.Subject.ToListAsync());
            }

            else
            {
                HttpContext.Session.Clear();

                return RedirectToAction("Login", "Login");
            }
        }

        // GET: Subject/Details/5
        public async Task<IActionResult> SubjectDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subjects = await _context.Subject
                .SingleOrDefaultAsync(m => m.Subject_Id == id);
            if (subjects == null)
            {
                return NotFound();
            }

            return View(subjects);
        }

        // GET: Subject/Create
        public IActionResult CreateSubject()
        {
            if (HttpContext.Session.GetString("AccountType") == "Register")
            {
                return View();
            }

            else
            {
                HttpContext.Session.Clear();

                return RedirectToAction("Login", "Login");
            }
            
        }

        // POST: Subject/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSubject([Bind("Subject_Id,Subject_Name")] Subjects subjects)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subjects);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(SubjectIndex));
            }
            return View(subjects);
        }

        // GET: Subject/Edit/5
        public async Task<IActionResult> EditSubject(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subjects = await _context.Subject.SingleOrDefaultAsync(m => m.Subject_Id == id);
            if (subjects == null)
            {
                return NotFound();
            }
            return View(subjects);
        }

        // POST: Subject/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditSubject(int id, [Bind("Subject_Id,Subject_Name")] Subjects subjects)
        {
            if (id != subjects.Subject_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subjects);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubjectsExists(subjects.Subject_Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(SubjectIndex));
            }
            return View(subjects);
        }

        // GET: Subject/Delete/5
        public async Task<IActionResult> DeleteSubject(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subjects = await _context.Subject
                .SingleOrDefaultAsync(m => m.Subject_Id == id);
            if (subjects == null)
            {
                return NotFound();
            }

            return View(subjects);
        }

        // POST: Subject/Delete/5
        [HttpPost, ActionName("DeleteSubject")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteSubjectConfirmed(int id)
        {
            var subjects = await _context.Subject.SingleOrDefaultAsync(m => m.Subject_Id == id);
            _context.Subject.Remove(subjects);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(SubjectIndex));
        }

        private bool SubjectsExists(int id)
        {
            return _context.Subject.Any(e => e.Subject_Id == id);
        }


        // GET: Teachers
        public async Task<IActionResult> TeacherIndex()
        {
            if (HttpContext.Session.GetString("AccountType") == "Register")
            {
                return View(await _context.Teachers.ToListAsync());

            }

            else
            {
                HttpContext.Session.Clear();

                return RedirectToAction("Login", "Login");
            }
        }

        // GET: Teachers/Details/5
        public async Task<IActionResult> TeacherDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacher = await _context.Teachers
                .SingleOrDefaultAsync(m => m.Teacher_Id == id);
            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        // GET: Teachers/Create
        public IActionResult TeacherCreate()
        {
            if (HttpContext.Session.GetString("AccountType") == "Register")
            {
                return View();

            }

            else
            {
                HttpContext.Session.Clear();

                return RedirectToAction("Login", "Login");
            }
        }

        // POST: Teachers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TeacherCreate([Bind("Teacher_Id,Teacher_Name,Designation,Contact")] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teacher);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(TeacherIndex));
            }
            return View(teacher);
        }

        // GET: Teachers/Edit/5
        public async Task<IActionResult> TeacherEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacher = await _context.Teachers.SingleOrDefaultAsync(m => m.Teacher_Id == id);
            if (teacher == null)
            {
                return NotFound();
            }
            return View(teacher);
        }

        // POST: Teachers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TeacherEdit(int id, [Bind("Teacher_Id,Teacher_Name,Designation,Contact")] Teacher teacher)
        {
            if (id != teacher.Teacher_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teacher);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeacherExists(teacher.Teacher_Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(TeacherIndex));
            }
            return View(teacher);
        }

        // GET: Teachers/Delete/5
        public async Task<IActionResult> TeacherDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacher = await _context.Teachers
                .SingleOrDefaultAsync(m => m.Teacher_Id == id);
            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        // POST: Teachers/Delete/5
        [HttpPost, ActionName("DeleteTeacher")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteTeacherConfirmed(int id)
        {
            var teacher = await _context.Teachers.SingleOrDefaultAsync(m => m.Teacher_Id == id);
            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(TeacherIndex));
        }

        private bool TeacherExists(int id)
        {
            return _context.Teachers.Any(e => e.Teacher_Id == id);
        }
    }
}
