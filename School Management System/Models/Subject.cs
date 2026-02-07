using Microsoft.Build.Tasks.Deployment.Bootstrapper;

namespace School_Management_System.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public required ICollection<Exam> Exams { get; set; }
        public required ICollection<SubjectTeacher> SubjectTeachers { get; set; }


    }
}
