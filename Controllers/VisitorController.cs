using lab2_gym.Data;
using lab2_gym.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace lab2_gym.Controllers
{
    public class VisitorsController : Controller
    {
        private readonly AppDbContext _context;

        public VisitorsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Visitors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Visitors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Visitor visitor)
        {
            if (ModelState.IsValid)
            {
                _context.Visitors.Add(visitor);
                await _context.SaveChangesAsync();

                ViewBag.Message = "Відвідувача успішно зареєстровано!";
                ModelState.Clear();
                return View();
            }

            return View(visitor);
        }

        // GET: Visitors
        public async Task<IActionResult> Index()
        {
            var visitors = await _context.Visitors.ToListAsync();
            return View(visitors);
        }

        // GET: Visitors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var visitor = await _context.Visitors.FindAsync(id);
            if (visitor == null)
                return NotFound();

            return View(visitor);
        }

        // GET: Visitors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var visitor = await _context.Visitors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (visitor == null)
                return NotFound();

            return View(visitor);
        }

        // POST: Visitors/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int Id, string FirstName, string LastName, string Phone, string Email)
        {
            var visitor = await _context.Visitors.FindAsync(Id);
            if (visitor == null)
                return NotFound();

            visitor.FirstName = FirstName;
            visitor.LastName = LastName;
            visitor.Phone = Phone;
            visitor.Email = Email;

            if (ModelState.IsValid)
            {
                _context.Update(visitor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        private bool VisitorExists(int id)
        {
            return _context.Visitors.Any(e => e.Id == id);
        }
    }
}
