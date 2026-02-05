using School_Management_System.Data;
using School_Management_System.Models;
using School_Management_System.Repositories.IRepositories;

namespace School_Management_System.Repositories
{
    public class SubjectRepository : Repository<Subject>, ISubjectRepository
    {
        private readonly ApplicationDbContext _context;

        public SubjectRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Subject subject)
        {
            _context.Subjects.Update(subject);
        }
    }
}
