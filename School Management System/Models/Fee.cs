namespace School_Management_System.Models
{
    public class Fee
    {
        public int Id { get; set; }
        public float Paid { get; set; }
        public float Amount { get; set; }
        public DateTime DueDate { get; set; }
        public int StudentId { get; set; }

        public required Student Student { get; set; }
    }
}
