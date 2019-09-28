using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolWeb.Models;

namespace SchoolWeb.Controllers
{
    public class ResultsController : Controller
    {
        private readonly DataContext _context;

        public ResultsController(DataContext context)
        {
            _context = context;
        }

        // GET: Results
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Result.Include(r => r.Class).Include(r => r.ExamType).Include(r => r.Section).Include(r => r.Subject);
            return View(await dataContext.ToListAsync());
        }

        // GET: Results/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var results = await _context.Result
                .Include(r => r.Class)
                .Include(r => r.ExamType)
                .Include(r => r.Section)
                .Include(r => r.Subject)
                .SingleOrDefaultAsync(m => m.Result_Id == id);
            if (results == null)
            {
                return NotFound();
            }

            return View(results);
        }

        // GET: Results/Create
        public IActionResult Create()
        {
            ViewData["Class_Id"] = new SelectList(_context.Class, "Class_Id", "Class_Name");
            ViewData["ExamType_Id"] = new SelectList(_context.ExamType, "ExamType_Id", "ExamType_Name");
            ViewData["Section_Id"] = new SelectList(_context.Section, "Section_Id", "Section_Name");
            ViewData["Subject_Id"] = new SelectList(_context.Subject, "Subject_Id", "Subject_Name");
            return View();
        }

        // POST: Results/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Result_Id,Student_Id,Class_Id,Section_Id,Subject_Id,ExamType_Id,Mark,Year")] Results results)
        {
            if (ModelState.IsValid)
            {
                _context.Add(results);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Class_Id"] = new SelectList(_context.Class, "Class_Id", "Class_Name", results.Class_Id);
            ViewData["ExamType_Id"] = new SelectList(_context.ExamType, "ExamType_Id", "ExamType_Name", results.ExamType_Id);
            ViewData["Section_Id"] = new SelectList(_context.Section, "Section_Id", "Section_Name", results.Section_Id);
            ViewData["Subject_Id"] = new SelectList(_context.Subject, "Subject_Id", "Subject_Name", results.Subject_Id);
            return View(results);
        }

        // GET: Results/Edit/5
        public async Task<IActionResult> Edit(int? id)
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
            ViewData["Class_Id"] = new SelectList(_context.Class, "Class_Id", "Class_Name", results.Class_Id);
            ViewData["ExamType_Id"] = new SelectList(_context.ExamType, "ExamType_Id", "ExamType_Name", results.ExamType_Id);
            ViewData["Section_Id"] = new SelectList(_context.Section, "Section_Id", "Section_Name", results.Section_Id);
            ViewData["Subject_Id"] = new SelectList(_context.Subject, "Subject_Id", "Subject_Name", results.Subject_Id);
            return View(results);
        }

        // POST: Results/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Result_Id,Student_Id,Class_Id,Section_Id,Subject_Id,ExamType_Id,Mark,Year")] Results results)
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
            ViewData["Class_Id"] = new SelectList(_context.Class, "Class_Id", "Class_Name", results.Class_Id);
            ViewData["ExamType_Id"] = new SelectList(_context.ExamType, "ExamType_Id", "ExamType_Name", results.ExamType_Id);
            ViewData["Section_Id"] = new SelectList(_context.Section, "Section_Id", "Section_Name", results.Section_Id);
            ViewData["Subject_Id"] = new SelectList(_context.Subject, "Subject_Id", "Subject_Name", results.Subject_Id);
            return View(results);
        }

        // GET: Results/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var results = await _context.Result
                .Include(r => r.Class)
                .Include(r => r.ExamType)
                .Include(r => r.Section)
                .Include(r => r.Subject)
                .SingleOrDefaultAsync(m => m.Result_Id == id);
            if (results == null)
            {
                return NotFound();
            }

            return View(results);
        }

        // POST: Results/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var results = await _context.Result.SingleOrDefaultAsync(m => m.Result_Id == id);
            _context.Result.Remove(results);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResultsExists(int id)
        {
            return _context.Result.Any(e => e.Result_Id == id);
        }
    }
}
