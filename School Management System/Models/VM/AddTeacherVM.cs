namespace School_Management_System.Models.VM
{
    public class AddTeacherVM
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public float Salary { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public int SubjectId { get; set; }
        
    }
}
