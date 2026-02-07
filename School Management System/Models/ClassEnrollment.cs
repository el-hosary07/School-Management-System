namespace School_Management_System.Models
{
    public class ClassEnrollment
    {
        public int Id { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public bool Status { get; set; }

        public int StudentId { get; set; }
        public int ClassId { get; set; }

        public required Student Student { get; set; }
        public required Class Class { get; set; }

    }
}
