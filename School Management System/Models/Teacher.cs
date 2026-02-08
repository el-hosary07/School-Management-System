using Microsoft.Build.Tasks.Deployment.Bootstrapper;

namespace School_Management_System.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public float Salary { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }



        public  Exam Exam { get; set; }
        public  ICollection<ExamResult> ExamResults { get; set; }
        public  ICollection<Class> Classes { get; set; }
        public  ICollection<SubjectTeacher> SubjectTeachers { get; set; }

    }
}
