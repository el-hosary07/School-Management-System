namespace School_Management_System.Models
{
    public class Exam
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ExamDate { get; set; }
        public int SubjectId { get; set; }
        public int TeacherId { get; set; }

        public  Subject Subject { get; set; }
        public  Teacher Teacher { get; set; }
        public  ICollection<ExamResult> ExamResults { get; set; }

    }
}
