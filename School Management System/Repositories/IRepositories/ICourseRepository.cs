using School_Management_System.Models;

namespace School_Management_System.Repositories.IRepositories
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetAll();
        Course GetById(int id);
        void Add(Course course);
        void Update(Course course);
        void Delete(int id);
        void Save();
    }

}
