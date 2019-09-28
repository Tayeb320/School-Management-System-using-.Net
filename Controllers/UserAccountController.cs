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
    public class UserAccountController : Controller
    {
        private readonly DataContext _context;

        public UserAccountController(DataContext context)
        {
            _context = context;
        }

        // GET: UserAccount
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("AccountType") == "SystemAdmin")
            {

                return View(await _context.UserAccounts.ToListAsync());
            }

            else
            {
                HttpContext.Session.Clear();

                return RedirectToAction("Login", "Login");
            }
            
        }

        // GET: UserAccount/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (HttpContext.Session.GetString("AccountType") == "SystemAdmin")
            {
                if (id == null)
                {
                    return NotFound();
                }

                var userAccounts = await _context.UserAccounts
                    .SingleOrDefaultAsync(m => m.UserId == id);
                if (userAccounts == null)
                {
                    return NotFound();
                }

                return View(userAccounts);
            }
            else
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Login", "Login");
            }
              
        }

        // GET: UserAccount/Create
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("AccountType") == "SystemAdmin")
            {
                return View();

            }
            else
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Login", "Login");
            }
               
        }

        // POST: UserAccount/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,Username,StudentId,Account_Type,Email,Password,ComfirmPassword")] UserAccounts userAccounts)
        {
            if (HttpContext.Session.GetString("AccountType") == "SystemAdmin")
            {
                if (ModelState.IsValid)
                {
                    _context.Add(userAccounts);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(userAccounts);
            }
            else
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Login", "Login");
            }
               
        }

        // GET: UserAccount/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (HttpContext.Session.GetString("AccountType") == "SystemAdmin")
            {
                if (id == null)
                {
                    return NotFound();
                }

                var userAccounts = await _context.UserAccounts.SingleOrDefaultAsync(m => m.UserId == id);
                if (userAccounts == null)
                {
                    return NotFound();
                }
                return View(userAccounts);
            }
            else
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Login", "Login");
            }
                
        }

        // POST: UserAccount/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,Username,StudentId,Account_Type,Email,Password,ComfirmPassword")] UserAccounts userAccounts)
        {
            if (HttpContext.Session.GetString("AccountType") == "SystemAdmin")
            {
                if (id != userAccounts.UserId)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(userAccounts);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!UserAccountsExists(userAccounts.UserId))
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
                return View(userAccounts);
            }
            else
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Login", "Login");
            }
               
        }

        // GET: UserAccount/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (HttpContext.Session.GetString("AccountType") == "SystemAdmin")
            {
                if (id == null)
                {
                    return NotFound();
                }

                var userAccounts = await _context.UserAccounts
                    .SingleOrDefaultAsync(m => m.UserId == id);
                if (userAccounts == null)
                {
                    return NotFound();
                }

                return View(userAccounts);
            }
            else
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Login", "Login");
            }
        }

        // POST: UserAccount/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userAccounts = await _context.UserAccounts.SingleOrDefaultAsync(m => m.UserId == id);
            _context.UserAccounts.Remove(userAccounts);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserAccountsExists(int id)
        {
            return _context.UserAccounts.Any(e => e.UserId == id);
        }
    }
}
