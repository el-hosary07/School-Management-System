using Microsoft.AspNetCore.Mvc;
using School_Management_System.Data;
using School_Management_System.Models;

namespace School_Management_System.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class ClassController : Controller
    {
        private ApplicationDbContext _context = new();
        public IActionResult Index()
        {
            var classe = _context.Classes.AsQueryable();
            return View(classe);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Class classe)
        {
            _context.Classes.Add(classe);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var classe = _context.Classes.Find(id);

            if (classe is null)
                return RedirectToAction("NotFoundPage", "Home");

            return View(classe);
        }

        [HttpPost]
        public IActionResult Edit(Class classe)
        {
            _context.Classes.Update(classe);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var classe = _context.Classes.Find(id);

            if (classe is null)
                return RedirectToAction("NotFoundPage", "Home");

            _context.Classes.Remove(classe);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}




