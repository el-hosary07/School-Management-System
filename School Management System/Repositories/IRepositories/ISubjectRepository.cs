using School_Management_System.Models;

namespace School_Management_System.Repositories.IRepositories
{
    public interface ISubjectRepository : IRepository<Subject>
    {
        void Update(Subject subject);
    }
}
