using School_Management_System.Models;

namespace School_Management_System.Repositories.IRepositories
{
    public interface IUnitOfWork
    {
        ITeacherRepository Teacher { get; }
        ICourseRepository Course { get; }
        ISubjectRepository Subject { get; }

        IRepository<ApplicationUserOTP> ApplicationUserOTP { get; }
        Task<int> CommitAsync(CancellationToken cancellationToken = default);
    }
}
