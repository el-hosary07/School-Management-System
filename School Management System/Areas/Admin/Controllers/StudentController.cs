using Microsoft.AspNetCore.Mvc;
using School_Management_System.Data;
using School_Management_System.Models;

namespace School_Management_System.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class StudentController : Controller
    {
        private ApplicationDbContext _context = new();
        public IActionResult Index()
        {
            var student = _context.Students.AsQueryable();
            return View(student);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var student = _context.Students.Find(id);

            if (student is null)
                return RedirectToAction("NotFoundPage", "Home");

            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var student = _context.Students.Find(id);

            if (student is null)
                return RedirectToAction("NotFoundPage", "Home");

            _context.Students.Remove(student);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}




