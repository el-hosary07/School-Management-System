namespace School_Management_System.Models
{
    public class BookIssue
    {
        public int Id { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public int StudentId { get; set; }
        public int BookId { get; set; }
    }
}
