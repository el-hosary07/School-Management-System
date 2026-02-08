using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School_Management_System.Data;
using School_Management_System.Models;
using School_Management_System.Models.VM;

namespace School_Management_System.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class StudentController : Controller
    {
        private ApplicationDbContext _context = new();
        public IActionResult Index()
        {
            var students = _context.Students
                .Include(s => s.ClassEnrollments)
                .ThenInclude(ce => ce.Class)
                .Select(s => new StudentVM
                {
                    Id = s.Id,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    ClassName = s.ClassEnrollments.FirstOrDefault().Class.Name+" "+ s.ClassEnrollments.FirstOrDefault().Class.Section
                })
                .ToList();

            return View(students);
        }



        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Classes = _context.Classes.ToList();  // للـ dropdown
            return View(new AddStudentVM());
        }

        [HttpPost]
        public IActionResult Add(AddStudentVM model)
        {
            if (model.Password == model.ConfirmPassword)
            {
                
                var student = new Student
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    BD = model.BD,
                    Email = model.Email,
                    Password = model.Password,
                    ConfirmPassword = model.Password,
                    Phone = model.Phone,
                    ClassEnrollments = new List<ClassEnrollment>() 
                };

                _context.Students.Add(student);
                _context.SaveChanges();


                var enrollment = new ClassEnrollment
                {
                    StudentId = student.Id,
                    ClassId = model.ClassId,
                    EnrollmentDate = DateTime.Now,
                    Status = true
                };

                _context.ClassEnrollments.Add(enrollment);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Classes = _context.Classes.ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var student = _context.Students
                .Include(s => s.ClassEnrollments)
                .ThenInclude(ce => ce.Class)
                .FirstOrDefault(s => s.Id == id);

            if (student == null)
                return RedirectToAction("NotFoundPage", "Home");

            var model = new AddStudentVM
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email,
                Phone = student.Phone,
                BD = student.BD,
                ClassId = student.ClassEnrollments?.FirstOrDefault()?.ClassId ?? 0
            };

            ViewBag.Classes = _context.Classes.ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(int id, AddStudentVM model)
        {
          

            if (ModelState.IsValid)
            {
                var student = _context.Students.Find(id);
                if (student == null)
                    return RedirectToAction("NotFoundPage", "Home");

                // Update Student
                student.FirstName = model.FirstName;
                student.LastName = model.LastName;
                student.Email = model.Email;
                student.Phone = model.Phone;
                student.BD = model.BD;

                // Update Class Enrollment
                var enrollment = student.ClassEnrollments?.FirstOrDefault();
                if (enrollment != null)
                {
                    enrollment.ClassId = model.ClassId;
                }
                else if (model.ClassId > 0)
                {
                    // Add new enrollment if none exists
                    enrollment = new ClassEnrollment
                    {
                        StudentId = student.Id,
                        ClassId = model.ClassId,
                        EnrollmentDate = DateTime.Now,
                        Status = true
                    };
                    _context.ClassEnrollments.Add(enrollment);
                }

                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Classes = _context.Classes.ToList();
            return View(model);
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




