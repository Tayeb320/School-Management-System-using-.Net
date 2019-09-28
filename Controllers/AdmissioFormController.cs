using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolWeb.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KayerHighSchool.Controllers
{
    public class AdmissionFormController : Controller
    {
        private readonly DataContext _Context;

        public AdmissionFormController(DataContext context)
        {
            _Context = context;
        }

        [HttpGet]
        public IActionResult Admission()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Admission(Admission model)
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

                _Context.Admitted.Add(newAdmit);
                _Context.SaveChanges();

                ViewBag.Success = "Successfully submitted";
            }

            catch(Exception e)
            {
                ViewBag.Message = "Fill up the form and try again";
            }
            return View();

        }



        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}