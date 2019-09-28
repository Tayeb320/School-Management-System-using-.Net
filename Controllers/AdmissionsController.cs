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
    public class AdmissionsController : Controller
    {
        private readonly DataContext _context;

        public AdmissionsController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Search()
        {
            if (HttpContext.Session.GetString("AccountType") == "AdmissionAdmin")
            {

                return View();
            }

            else
            {
                HttpContext.Session.Clear();

                return RedirectToAction("Login", "Login");
            }
            
        }
        public IActionResult SearchStudent(string searchBy, string search)
        {
            if (HttpContext.Session.GetString("AccountType") == "AdmissionAdmin")
            {
                if (searchBy == "Name")
                {
                    var students = _context.Admitted.Where(u => u.StudentNameEng.StartsWith(search)).ToList();
                    return View(students);
                }
                if (searchBy == "Id")
                {
                    try
                    {
                        int id = Int32.Parse(search);
                        var students = _context.Admitted.Where(u => u.StudentId == id).ToList();
                        return View(students);
                    }
                    catch (Exception e)
                    {
                        ViewBag.Message = "Please Input Correct Id";
                    }

                }

                if (searchBy == "Class")
                {
                    var students = _context.Admitted.Where(u => u.Class == search).ToList();
                    return View(students);
                }
                return View("SearchStudent");

            }

            else
            {
                HttpContext.Session.Clear();

                return RedirectToAction("Login", "Login");
            }
            
        }
        //public void UserName()
        //{
        //    var user = HttpContext.Session.Get("userName");
        //    string username = System.Text.Encoding.UTF8.GetString(user);
        //    TempData["userName"] = username;
        //}
        // GET: Admissions
        public async Task<IActionResult> Index()
        {
            if(HttpContext.Session.GetString("AccountType") == "AdmissionAdmin")
            {

                return View(await _context.Admitted.ToListAsync());
            }

           else
            {
                HttpContext.Session.Clear();

                return RedirectToAction("Login", "Login");
            }
        }

        // GET: Admissions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (HttpContext.Session.GetString("AccountType") == "AdmissionAdmin")
            {

                if (id == null)
                {
                    return NotFound();
                }

                var admission = await _context.Admitted
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

        // GET: Admissions/Create
        public IActionResult Create()
        {
            if(HttpContext.Session.GetString("AccountType")== "AdmissionAdmin")
            {
                return View();
            }
            else
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Login", "Login");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Admission model)
        {
            if(HttpContext.Session.GetString("AccountType") == "AdmissionAdmin")
            {
                try
                {
                    Admission newAdmit = new Admission()
                    {

                        StudentNameBan = model.StudentNameBan,
                        StudentNameEng = model.StudentNameEng,
                        Class = model.Class,
                        FatherName = model.FatherName,
                        MotherName = model.MotherName,
                        Guardian = model.Guardian,
                        PerVill = model.PerVill,
                        PerPost = model.PerPost,
                        PerZila = model.PerZila,
                        PreVill = model.PreVill,
                        PrePost = model.PrePost,
                        PreZila = model.PreZila,
                        Birthdate = model.Birthdate,
                        Religion = model.Religion,
                        LastSchool = model.LastSchool,
                        GuardianDetails = model.GuardianDetails,
                        Contact = model.Contact,
                    };

                    _context.Admitted.Add(newAdmit);
                    _context.SaveChanges();

                    ViewBag.Success = "Successfully submitted";
                    return RedirectToAction("Index");
                }

                catch (Exception e)
                {
                    ViewBag.Message = "Please fill up the form and try again";

                }
                return View();
            }
            else
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Login", "Login");
            }
            

        }
        // GET: Admissions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (HttpContext.Session.GetString("AccountType") == "AdmissionAdmin")
            {
                if (id == null)
                {
                    return NotFound();
                }

                var admission = await _context.Admitted.SingleOrDefaultAsync(m => m.StudentId == id);
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

        // POST: Admissions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentId,Class,StudentNameBan,StudentNameEng,FatherName,MotherName,Guardian,PerVill,PerPost,PerZila,PreVill,PrePost,PreZila,Birthdate,Religion,LastSchool,GuardianDetails,Contact")] Admission admission)
        {
            if (HttpContext.Session.GetString("AccountType") == "AdmissionAdmin")
            {
                if (id != admission.StudentId)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(admission);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!AdmissionExists(admission.StudentId))
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
                return View(admission);
            }
            else
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Login", "Login");
            }


        }

        // GET: Admissions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (HttpContext.Session.GetString("AccountType") == "AdmissionAdmin")
            {
                if (id == null)
                {
                    return NotFound();
                }

                var admission = await _context.Admitted
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

        // POST: Admissions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var admission = await _context.Admitted.SingleOrDefaultAsync(m => m.StudentId == id);
            _context.Admitted.Remove(admission);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdmissionExists(int id)
        {
            return _context.Admitted.Any(e => e.StudentId == id);
        }
        
    }
}
