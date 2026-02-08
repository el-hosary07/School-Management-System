using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School_Management_System.Data;
using School_Management_System.Models;

namespace School_Management_System.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ClassController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClassController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var classes = _context.Classes
                .Include(c => c.Teacher)
                .Include(c => c.ClassEnrollments)
                .ThenInclude(ce => ce.Student)
                .ToList();
            return View(classes);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Teachers = _context.Teachers.ToList();
            return View(new Class());
        }

        [HttpPost]
        public IActionResult Add(Class classObj)
        {
            if (ModelState.IsValid)
            {
                _context.Classes.Add(classObj);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Teachers = _context.Teachers.ToList();
            return View(classObj);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var classObj = _context.Classes.Find(id);
            if (classObj == null) return NotFound();

            ViewBag.Teachers = _context.Teachers.ToList();
            return View(classObj);
        }

        [HttpPost]
        public IActionResult Edit(int id, Class classObj)
        {
            if (id != classObj.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(classObj);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Teachers = _context.Teachers.ToList();
            return View(classObj);
        }




        public IActionResult Delete(int id)
        {
            var classObj = _context.Classes.Find(id);
            if (classObj != null)
            {
                // حذف ClassEnrollments أولاً
                var enrollments = _context.ClassEnrollments.Where(e => e.ClassId == id);
                _context.ClassEnrollments.RemoveRange(enrollments);

                _context.Classes.Remove(classObj);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var classObj = _context.Classes
                .Include(c => c.Teacher)
                .Include(c => c.ClassEnrollments)
                .ThenInclude(ce => ce.Student)
                .FirstOrDefault(c => c.Id == id);

            if (classObj == null) return NotFound();
            return View(classObj);
        }
    }
}
