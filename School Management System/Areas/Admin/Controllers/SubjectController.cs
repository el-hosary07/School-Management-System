using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School_Management_System.Data;
using School_Management_System.Models;

namespace School_Management_System.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SubjectController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SubjectController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var subjects = _context.Subjects
                .Include(s => s.SubjectTeachers)
                .ThenInclude(st => st.Teacher)
                .ToList();
            return View(subjects);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Teachers = _context.Teachers.ToList();
            return View(new Subject());
        }

        [HttpPost]
        public IActionResult Add(Subject subject, int[] selectedTeachers)
        {
            if (ModelState.IsValid)
            {
                // 1. إضافة المادة
                _context.Subjects.Add(subject);
                _context.SaveChanges();

                // 2. ربط المدرسين بالمادة
                if (selectedTeachers != null && selectedTeachers.Length > 0)
                {
                    foreach (var teacherId in selectedTeachers)
                    {
                        _context.SubjectTeachers.Add(new SubjectTeacher
                        {
                            SubjectId = subject.Id,
                            TeacherId = teacherId
                        });
                    }
                    _context.SaveChanges();
                }

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Teachers = _context.Teachers.ToList();
            return View(subject);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var subject = _context.Subjects
                .Include(s => s.SubjectTeachers)
                .ThenInclude(st => st.Teacher)
                .FirstOrDefault(s => s.Id == id);

            if (subject == null) return NotFound();

            // تحضير قائمة المدرسين المختارين
            var selectedTeacherIds = subject.SubjectTeachers?.Select(st => st.TeacherId).ToArray() ?? new int[0];
            ViewBag.SelectedTeachers = selectedTeacherIds;
            ViewBag.Teachers = _context.Teachers.ToList();

            return View(subject);
        }

        [HttpPost]
        public IActionResult Edit(int id, Subject subject, int[] selectedTeachers)
        {
            if (id != subject.Id) return NotFound();

            if (ModelState.IsValid)
            {
                // 1. تحديث المادة
                _context.Subjects.Update(subject);
                _context.SaveChanges();

                // 2. حذف العلاقات القديمة
                var oldRelations = _context.SubjectTeachers.Where(st => st.SubjectId == id);
                _context.SubjectTeachers.RemoveRange(oldRelations);
                _context.SaveChanges();

                // 3. إضافة العلاقات الجديدة
                if (selectedTeachers != null && selectedTeachers.Length > 0)
                {
                    foreach (var teacherId in selectedTeachers)
                    {
                        _context.SubjectTeachers.Add(new SubjectTeacher
                        {
                            SubjectId = subject.Id,
                            TeacherId = teacherId
                        });
                    }
                    _context.SaveChanges();
                }

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Teachers = _context.Teachers.ToList();
            return View(subject);
        }

        public IActionResult Delete(int id)
        {
            var subject = _context.Subjects.Find(id);
            if (subject != null)
            {
                // حذف العلاقات أولاً
                var relations = _context.SubjectTeachers.Where(st => st.SubjectId == id);
                _context.SubjectTeachers.RemoveRange(relations);

                _context.Subjects.Remove(subject);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }

}




