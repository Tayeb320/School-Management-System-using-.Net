using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolWeb.Models;
using SchoolWeb.ViewModel;

namespace SchoolWeb.Controllers
{
    public class TeacherController : Controller
    {
        private readonly DataContext _context;

        public TeacherController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Profile()
        {
            if (HttpContext.Session.GetString("AccountType") == "Teacher")
            {
                string tId = HttpContext.Session.GetString("TeacherId");
                int id = int.Parse(tId);
                if (id == 0)
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
            else
            {
                HttpContext.Session.Clear();

                return RedirectToAction("Login", "Login");
            }
        }

        public IActionResult Search()
        {
            return View();
        }

        // GET: Result
        public IActionResult Index()
        {
            var result = (from r in _context.Result

                          join stu in _context.Admitted
                          on r.Student_Id equals stu.StudentId

                          join cls in _context.Class
                          on r.Class_Id equals cls.Class_Id

                          join sec in _context.Section
                          on r.Section_Id equals sec.Section_Id

                          join sub in _context.Subject
                          on r.Subject_Id equals sub.Subject_Id

                          join xm in _context.ExamType
                          on r.ExamType_Id equals xm.ExamType_Id

                          select new StudentResultViewModel
                          {
                              Id = r.Result_Id,
                              StudentId = stu.StudentId,
                              StudentName = stu.StudentNameEng,
                              Class = cls.Class_Name,
                              Section = sec.Section_Name,
                              Subject = sub.Subject_Name,
                              ExamType = xm.ExamType_Name,
                              Mark = r.Mark,
                              Year = r.Year
                          }).ToList();
            return View(result);
        }

        //search result 
        public IActionResult SearchResult(string searchBy , string search)
        {

                if (searchBy == "Name")
                {
                    var result = (from r in _context.Result

                                  join stu in _context.Admitted
                                  on r.Student_Id equals stu.StudentId

                                  join cls in _context.Class
                                  on r.Class_Id equals cls.Class_Id

                                  join sec in _context.Section
                                  on r.Section_Id equals sec.Section_Id

                                  join sub in _context.Subject
                                  on r.Subject_Id equals sub.Subject_Id

                                  join xm in _context.ExamType
                                  on r.ExamType_Id equals xm.ExamType_Id

                                  where stu.StudentNameEng.StartsWith(search) || search == null
                                  select new StudentResultViewModel
                                  {
                                      Id = r.Result_Id,
                                      StudentId = stu.StudentId,
                                      StudentName = stu.StudentNameEng,
                                      Class = cls.Class_Name,
                                      Section = sec.Section_Name,
                                      Subject = sub.Subject_Name,
                                      ExamType = xm.ExamType_Name,
                                      Mark = r.Mark,
                                      Year = r.Year
                                  }).ToList();
                    return View(result);
                }

                if (searchBy == "Id")
                {
                    var result = (from r in _context.Result

                                  join stu in _context.Admitted
                                  on r.Student_Id equals stu.StudentId

                                  join cls in _context.Class
                                  on r.Class_Id equals cls.Class_Id

                                  join sec in _context.Section
                                  on r.Section_Id equals sec.Section_Id

                                  join sub in _context.Subject
                                  on r.Subject_Id equals sub.Subject_Id

                                  join xm in _context.ExamType
                                  on r.ExamType_Id equals xm.ExamType_Id

                                  where stu.StudentId.ToString() == search || search == null
                                  select new StudentResultViewModel
                                  {
                                      Id = r.Result_Id,
                                      StudentId = stu.StudentId,
                                      StudentName = stu.StudentNameEng,
                                      Class = cls.Class_Name,
                                      Section = sec.Section_Name,
                                      Subject = sub.Subject_Name,
                                      ExamType = xm.ExamType_Name,
                                      Mark = r.Mark,
                                      Year = r.Year
                                  }).ToList();
                    return View(result);
                }

            return View("SearchResult");
        }

        // GET: Result/Details/5
        public IActionResult DetailsResult(int? id)
        {
            var result = (from r in _context.Result

                          join stu in _context.Admitted
                          on r.Student_Id equals stu.StudentId

                          join cls in _context.Class
                          on r.Class_Id equals cls.Class_Id

                          join sec in _context.Section
                          on r.Section_Id equals sec.Section_Id

                          join sub in _context.Subject
                          on r.Subject_Id equals sub.Subject_Id

                          join xm in _context.ExamType
                          on r.ExamType_Id equals xm.ExamType_Id
                          where r.Section_Id==id

                          select new StudentResultViewModel
                          {
                              Id = r.Result_Id,
                              StudentId = stu.StudentId,
                              StudentName = stu.StudentNameEng,
                              Class = cls.Class_Name,
                              Section = sec.Section_Name,
                              Subject = sub.Subject_Name,
                              ExamType = xm.ExamType_Name,
                              Mark = r.Mark,
                              Year = r.Year
                          }).First<StudentResultViewModel>();
            return View(result);
        }

        // GET: Result/Create
        public IActionResult CreateResult()
        {

            ViewData["Student_Id"] = new SelectList(_context.Admitted, "StudentId", "StudentNameEng");
            ViewData["Class_Id"] = new SelectList(_context.Class, "Class_Id", "Class_Name");
            ViewData["Section_Id"] = new SelectList(_context.Section, "Section_Id", "Section_Name");
            //ViewData["GroupName"] = new SelectList(_context.Class, "Group_Id", "Group_Name");
            ViewData["Subject_Id"] = new SelectList(_context.Subject, "Subject_Id", "Subject_Name");
            ViewData["ExamType_Id"] = new SelectList(_context.ExamType, "ExamType_Id", "ExamType_Name");
           
            return View();
        }

        // POST: Result/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateResult([Bind("Result_Id,Student_Id,Class_Id,Section_Id,Subject_Id,ExamType_Id,Mark,Year")] Results results)
        {
            if (ModelState.IsValid)
            {
                _context.Add(results);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["Student_Id"] = new SelectList(_context.Admitted, "StudentId", "StudentNameEng", results.Section_Id);
            ViewData["Class_Id"] = new SelectList(_context.Class, "Class_Id", "Class_Name", results.Class_Id);
            ViewData["Section_Id"] = new SelectList(_context.Section, "Section_Id", "Section_Name", results.Section_Id);
            //ViewData["GroupName"] = new SelectList(_context.Class, "Group_Id", "Group_Name");
            ViewData["Subject_Id"] = new SelectList(_context.Subject, "Subject_Id", "Subject_Name", results.Subject_Id);
            ViewData["ExamType_Id"] = new SelectList(_context.ExamType, "ExamType_Id", "ExamType_Name", results.ExamType_Id);
            return View(results);
        }

        // GET: Result/Edit/5
        public async Task<IActionResult> EditResult(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var results = await _context.Result.SingleOrDefaultAsync(m => m.Result_Id == id);
            if (results == null)
            {
                return NotFound();
            }
            ViewData["Student_Id"] = new SelectList(_context.Admitted, "StudentId", "StudentNameEng", results.Section_Id);
            ViewData["Class_Id"] = new SelectList(_context.Class, "Class_Id", "Class_Name", results.Class_Id);
            ViewData["Section_Id"] = new SelectList(_context.Section, "Section_Id", "Section_Name", results.Section_Id);
            //ViewData["GroupName"] = new SelectList(_context.Class, "Group_Id", "Group_Name");
            ViewData["Subject_Id"] = new SelectList(_context.Subject, "Subject_Id", "Subject_Name", results.Subject_Id);
            ViewData["ExamType_Id"] = new SelectList(_context.ExamType, "ExamType_Id", "ExamType_Name", results.ExamType_Id);

            return View(results);
        }

        // POST: Result/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditResult(int id, [Bind("Result_Id,Student_Id,Class_Id,Section_Id,Subject_Id,ExamType_Id,Mark,Year")] Results results)
        {
            if (id != results.Result_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(results);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResultsExists(results.Result_Id))
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
            ViewData["Student_Id"] = new SelectList(_context.Admitted, "StudentId", "StudentNameEng", results.Section_Id);
            ViewData["Class_Id"] = new SelectList(_context.Class, "Class_Id", "Class_Name", results.Class_Id);
            ViewData["Section_Id"] = new SelectList(_context.Section, "Section_Id", "Section_Name", results.Section_Id);
            //ViewData["GroupName"] = new SelectList(_context.Class, "Group_Id", "Group_Name");
            ViewData["Subject_Id"] = new SelectList(_context.Subject, "Subject_Id", "Subject_Name", results.Subject_Id);
            ViewData["ExamType_Id"] = new SelectList(_context.ExamType, "ExamType_Id", "ExamType_Name", results.ExamType_Id);
            return View(results);
        }

        // GET: Result/Delete/5
        public IActionResult DeleteResult(int? id)
        {
            var result = (from r in _context.Result

                          join stu in _context.Admitted
                          on r.Student_Id equals stu.StudentId

                          join cls in _context.Class
                          on r.Class_Id equals cls.Class_Id

                          join sec in _context.Section
                          on r.Section_Id equals sec.Section_Id

                          join sub in _context.Subject
                          on r.Subject_Id equals sub.Subject_Id

                          join xm in _context.ExamType
                          on r.ExamType_Id equals xm.ExamType_Id
                          where r.Section_Id == id

                          select new StudentResultViewModel
                          {
                              Id = r.Result_Id,
                              StudentId = stu.StudentId,
                              StudentName = stu.StudentNameEng,
                              Class = cls.Class_Name,
                              Section = sec.Section_Name,
                              Subject = sub.Subject_Name,
                              ExamType = xm.ExamType_Name,
                              Mark = r.Mark,
                              Year = r.Year
                          }).First<StudentResultViewModel>();
            return View(result);
        }

        // POST: Result/Delete/5
        [HttpPost, ActionName("DeleteResult")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteResultConfirmed(int id)
        {
            var results = await _context.Result.SingleOrDefaultAsync(m => m.Result_Id == id);
            _context.Result.Remove(results);
            await _context.SaveChangesAsync();

            ViewData["Student_Id"] = new SelectList(_context.Admitted, "StudentId", "StudentNameEng", results.Section_Id);
            ViewData["Class_Id"] = new SelectList(_context.Class, "Class_Id", "Class_Name", results.Class_Id);
            ViewData["Section_Id"] = new SelectList(_context.Section, "Section_Id", "Section_Name", results.Section_Id);
            //ViewData["GroupName"] = new SelectList(_context.Class, "Group_Id", "Group_Name");
            ViewData["Subject_Id"] = new SelectList(_context.Subject, "Subject_Id", "Subject_Name", results.Subject_Id);
            ViewData["ExamType_Id"] = new SelectList(_context.ExamType, "ExamType_Id", "ExamType_Name", results.ExamType_Id);
            return RedirectToAction(nameof(Index));
        }

        private bool ResultsExists(int id)
        {
            return _context.Result.Any(e => e.Result_Id == id);
        }
    }
}
