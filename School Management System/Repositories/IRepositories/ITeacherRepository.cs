using School_Management_System.Models;

namespace School_Management_System.Repositories.IRepositories
{
    public interface ITeacherRepository : IRepository<Teacher>
    {
        Teacher GetTeacherWithSubjects(int id);
        void Update(Teacher teacher);
    }
}
