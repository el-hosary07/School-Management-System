using School_Management_System.Data;
using School_Management_System.Models;
using School_Management_System.Repositories.IRepositories;

namespace School_Management_System.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IRepository<ApplicationUserOTP> ApplicationUserOTP { get; }
        public ITeacherRepository Teacher { get; private set; }
        public ICourseRepository Course { get; private set; }
        public ISubjectRepository Subject { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Teacher = new TeacherRepository(_context);
            Course = new CourseRepository(_context);
            Subject = new SubjectRepository(_context);
        }

        public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
