using lab2_gym.Data;
using lab2_gym.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;

namespace lab2_gym.Controllers
{
    public class SubscriptionController : Controller
    {
        private readonly AppDbContext _context;

        public SubscriptionController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Subscription/Index/{id?}
        public IActionResult Index(int? id)
        {
            ViewBag.Gyms = _context.Gyms.ToList();
            ViewBag.Visitors = _context.Visitors.ToList();
            ViewBag.Subscriptions = _context.Subscriptions
                .Include(s => s.Visitor)
                .Include(s => s.Gym)
                .ToList();

            Subscription subscription;

            if (id.HasValue)
            {
                subscription = _context.Subscriptions.FirstOrDefault(s => s.Id == id.Value);
                if (subscription == null)
                    return NotFound();
            }
            else
            {
                subscription = new Subscription
                {
                    StartDate = DateTime.Today,
                    EndDate = DateTime.Today.AddMonths(1)
                };
            }

            return View(subscription);
        }

        // POST: Subscription/Index
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Subscription model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Gyms = _context.Gyms.ToList();
                ViewBag.Visitors = _context.Visitors.ToList();
                ViewBag.Subscriptions = _context.Subscriptions
                    .Include(s => s.Visitor)
                    .Include(s => s.Gym)
                    .ToList();

                return View(model);
            }

            if (model.StartDate == DateTime.MinValue)
                model.StartDate = DateTime.Today;

            if (model.EndDate == DateTime.MinValue)
                model.EndDate = DateTime.Today.AddMonths(1);

            if (model.Id == 0)
            {
                _context.Subscriptions.Add(model);
            }
            else
            {
                var existing = _context.Subscriptions.AsNoTracking().FirstOrDefault(s => s.Id == model.Id);
                if (existing == null)
                    return NotFound();

                _context.Subscriptions.Update(model);
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Subscription");
        }

        public IActionResult Delete(int id)
        {
            var subscription = _context.Subscriptions.Find(id);
            if (subscription == null)
                return NotFound();

            _context.Subscriptions.Remove(subscription);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
