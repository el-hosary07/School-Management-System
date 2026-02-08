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


        public  ICollection<ClassEnrollment> ClassEnrollments { get; set; }
        public  ICollection<ExamResult> ExamResults { get; set; }
        public  ICollection<Attendance> Attendances { get; set; }
        public  ICollection<BookIssue> BookIssues { get; set; }
        public  ICollection<Fee> Fees { get; set; }
    }
}
