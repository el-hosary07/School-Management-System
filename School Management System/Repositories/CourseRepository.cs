using School_Management_System.Data;
using School_Management_System.Models;
using School_Management_System.Repositories.IRepositories;

namespace School_Management_System.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _context;

        public CourseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Course> GetAll()
        {
            return _context.Courses.ToList();
        }

        public Course GetById(int id)
        {
            return _context.Courses.Find(id);
        }

        public void Add(Course course)
        {
            _context.Courses.Add(course);
        }

        public void Update(Course course)
        {
            _context.Courses.Update(course);
        }

        public void Delete(int id)
        {
            var course = GetById(id);
            if (course != null)
                _context.Courses.Remove(course);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
