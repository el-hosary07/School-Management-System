namespace School_Management_System.Models
{
    public class ExamResult
    {
        public int Id { get; set; }
        public int Marks { get; set; }
        public int StudentId { get; set; }
        public int ExamId { get; set; }


        
        public  Student Student { get; set; }    
        public  Exam Exam { get; set; }

    }
}
