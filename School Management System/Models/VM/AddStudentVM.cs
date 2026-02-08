namespace School_Management_System.Models.VM
{
    public class AddStudentVM
    {
        public int Id { get; internal set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateOnly BD { get; set; }
        public string? Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Phone { get; set; }
        public int ClassId { get; set; }
        
    }
}
