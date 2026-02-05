namespace School_Management_System.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly BD { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
