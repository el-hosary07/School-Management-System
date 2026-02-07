using Microsoft.AspNetCore.Mvc;
using School_Management_System.Data;
using School_Management_System.Models;

namespace School_Management_System.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class SubjectController : Controller
    {
        private ApplicationDbContext _context = new();
        public IActionResult Index()
        {
            var subject = _context.Subjects.AsQueryable();
            return View(subject);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Subject subject)
        {
            _context.Subjects.Add(subject);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var subject = _context.Subjects.Find(id);

            if (subject is null)
                return RedirectToAction("NotFoundPage", "Home");

            return View(subject);
        }

        [HttpPost]
        public IActionResult Edit(Subject subject)
        {
            _context.Subjects.Update(subject);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var subject = _context.Subjects.Find(id);

            if (subject is null)
                return RedirectToAction("NotFoundPage", "Home");

            _context.Subjects.Remove(subject);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}




