using Microsoft.EntityFrameworkCore;
using School_Management_System.Data;
using School_Management_System.Models;
using School_Management_System.Repositories.IRepositories;

namespace School_Management_System.Repositories
{
    public class TeacherRepository : Repository<Teacher>, ITeacherRepository
    {
        private readonly ApplicationDbContext _context;

        public TeacherRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public Teacher GetTeacherWithSubjects(int id)
        {
            return _context.Teachers
                .Include(t => t.TeacherSubjects)
                .ThenInclude(ts => ts.Subject)
                .FirstOrDefault(t => t.Id == id);
        }

        public void Update(Teacher teacher)
        {
            _context.Teachers.Update(teacher);
        }
    }
}
