using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolWeb.Models;
using SchoolWeb.ViewModel;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolWeb.Controllers
{
    public class StudentController : Controller
    {

        private readonly DataContext _Context;

        //Constructor to get the database at the beginning
        public StudentController(DataContext context)
        {
            _Context = context;
        }

        // GET: Student/Profile/5

        public async Task<IActionResult> Profile()
        {
            if (HttpContext.Session.GetString("AccountType") == "Student")
            {
                string stdId = HttpContext.Session.GetString("StudentId");
                int id = int.Parse(stdId);
                if (id == 0)
                {
                    return NotFound();
                }

                var admission = await _Context.Admitted
                    .SingleOrDefaultAsync(m => m.StudentId == id);
                if (admission == null)
                {
                    return NotFound();
                }

                return View(admission);
            }

            else
            {
                HttpContext.Session.Clear();

                return RedirectToAction("Login", "Login");
            }

        }

        // Individual Result on Student panel

        public IActionResult Result()
        {
            string stdId = HttpContext.Session.GetString("StudentId");
            int id = int.Parse(stdId);
            if (id == 0)
            {
                return NotFound();
            }
            var result = (from r in _Context.Result

                          join stu in _Context.Admitted
                          on r.Student_Id equals stu.StudentId
                          where stu.StudentId == id

                          join cls in _Context.Class
                          on r.Class_Id equals cls.Class_Id

                          join sec in _Context.Section
                          on r.Section_Id equals sec.Section_Id

                          join sub in _Context.Subject
                          on r.Subject_Id equals sub.Subject_Id

                          join xm in _Context.ExamType
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
    }
}
