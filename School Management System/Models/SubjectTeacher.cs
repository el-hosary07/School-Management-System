namespace School_Management_System.Models
{
    public class SubjectTeacher
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public int SubjectId { get; set; }


        public required Teacher Teacher { get; set; }    
        public required Subject Subject { get; set; }
    }
}
