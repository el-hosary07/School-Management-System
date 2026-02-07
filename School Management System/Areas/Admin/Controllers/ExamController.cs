using Microsoft.AspNetCore.Mvc;
using School_Management_System.Data;
using School_Management_System.Models;

namespace School_Management_System.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class ExamController : Controller
    {
        private ApplicationDbContext _context = new();
        public IActionResult Index()
        {
            var exam = _context.Exams.AsQueryable();
            return View(exam);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Exam exam)
        {
            _context.Exams.Add(exam);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var exam = _context.Exams.Find(id);

            if (exam is null)
                return RedirectToAction("NotFoundPage", "Home");

            return View(exam);
        }

        [HttpPost]
        public IActionResult Edit(Exam exam)
        {
            _context.Exams.Update(exam);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var exam = _context.Exams.Find(id);

            if (exam is null)
                return RedirectToAction("NotFoundPage", "Home");

            _context.Exams.Remove(exam);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}




