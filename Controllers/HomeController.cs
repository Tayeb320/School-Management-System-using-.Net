using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolWeb.Models;

namespace SchoolWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Kayer High School is renowned for its higher quality education and a good number of quality faculty members. The school was established in 1973 for the requirement of quality education among the people of Kayer. After completing the education of our students they got admitted into different well known college and institutions and well established.";
            ViewData["Message2"] = "Against this backdrop of confusion and disorder in the education system of the country, we ventured to establish an ideal educational institution in the year 1973 named Kayer High School. It is located at Bara Kayer , Pubail-1721, Gazipur Sadar , Gazipur in Dhaka.";
            ViewData["GovtAppoval"] = "Kayer High School is approved by the Ministry of Education, Government of People’s Republic of Bangladesh, vide their letter no. sha 9168 (part) 313, dated, 9th December, 1972 and Board of Intermediate and Secondary Education, Dhaka, Letter no. 1546. Our College Code Number is 1056 & EIIN: 108572.";
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
