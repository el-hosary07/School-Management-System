using Microsoft.Build.Tasks.Deployment.Bootstrapper;

namespace School_Management_System.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateOnly BD { get; set; }
        public string? Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Phone { get; set; } = string.Empty;


        public required ICollection<ClassEnrollment> ClassEnrollments { get; set; }
        public required ICollection<ExamResult> ExamResults { get; set; }
        public required ICollection<Attendance> Attendances { get; set; }
        public required ICollection<BookIssue> BookIssues { get; set; }
        public required ICollection<Fee> Fees { get; set; }
    }
}
