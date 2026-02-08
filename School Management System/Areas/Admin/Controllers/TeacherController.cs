using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School_Management_System.Data;
using School_Management_System.Models;
using School_Management_System.Models.VM;

namespace School_Management_System.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class TeacherController : Controller
    {
        private ApplicationDbContext _context = new();
        public IActionResult Index()
        {
            var teachers = _context.Teachers
                .Include(t => t.SubjectTeachers)
                .ThenInclude(st => st.Subject)
                .Select(s => new TeacherVM
                {
                    Id = s.Id,
                    Name = s.Name,
                    SubjectName = s.SubjectTeachers.FirstOrDefault().Subject.Name 
                })
                .ToList();

            return View(teachers);
        }



        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Subjects = _context.Subjects.ToList();  // للـ dropdown
            return View(new AddTeacherVM());
        }

        [HttpPost]
        public IActionResult Add(AddTeacherVM model)
        {
            if (model.Password == model.ConfirmPassword)
            {
                
                var teacher = new Teacher
                {
                    Name = model.Name,
                    Salary = model.Salary,
                    Email = model.Email,
                    Password = model.Password,
                    ConfirmPassword = model.Password,
                    SubjectTeachers = new List<SubjectTeacher>() 
                };

                _context.Teachers.Add(teacher);
                _context.SaveChanges();


                var subjectTeacher = new SubjectTeacher
                {
                    TeacherId = teacher.Id,
                    SubjectId = model.SubjectId,

                };

                _context.SubjectTeachers.Add(subjectTeacher);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Subjects = _context.Subjects.ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var teacher = _context.Teachers.Find(id);
            if (teacher == null)
                return RedirectToAction("NotFoundPage", "Home");

            ViewBag.Classes = _context.Classes.ToList();  
            return View(teacher);
        }

        [HttpPost]
        public IActionResult Edit(int id, Teacher teacher)  
        {
            if (id != teacher.Id)
                return NotFound();

            _context.Teachers.Update(teacher);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var teacher = _context.Teachers.Find(id);

            if (teacher is null)
                return RedirectToAction("NotFoundPage", "Home");

            _context.Teachers.Remove(teacher);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}




