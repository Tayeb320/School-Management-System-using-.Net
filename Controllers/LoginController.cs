using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolWeb.Models;

namespace SchoolWeb.Controllers
{
    public class LoginController : Controller
    {
        private readonly DataContext _context;

        public LoginController(DataContext _context)
        {
            this._context = _context;
        }
        public IActionResult Index()
        {
            return RedirectToAction(nameof(Login));
        }

        public IActionResult Login()
        {
            if (HttpContext.Session.Get("userName") != null)
            {
                return View();
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login([Bind("Email, Password")] UserAccounts userAccount)
        {
           try
            {
                UserAccounts user = (from usr in _context.UserAccounts
                                     where usr.Email == userAccount.Email
                                    && usr.Password == userAccount.Password
                                     select usr).First<UserAccounts>();
                if (user != null)
                {
                    
                    HttpContext.Session.SetString("userName", user.Username);
                    HttpContext.Session.Get("userName");
                    HttpContext.Session.SetString("AccountType", user.Account_Type);

                    if (user.Account_Type.Equals("AdmissionAdmin"))
                    {
                        return RedirectToAction("Index", "Admissions");
                    }
                    else if (user.Account_Type.Equals("SystemAdmin"))
                    {
                        return RedirectToAction("Index", "UserAccount");
                    }
                    else if (user.Account_Type.Equals("Register"))
                    {
                        return RedirectToAction("Index", "Register");
                    }
                    else if (user.Account_Type.Equals("Teacher"))
                    {
                        HttpContext.Session.SetString("TeacherId", user.StudentId);
                        return RedirectToAction("Index", "Teacher");
                    }
                    else if (user.Account_Type.Equals("Student"))
                    {
                        HttpContext.Session.SetString("StudentId", user.StudentId);
                        return RedirectToAction("Profile", "Student");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception e)
            {
                ViewBag.Message = "Username or password wrong";
            }
            return View();
        }  
        
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction(nameof(Index));
        }
    }
}