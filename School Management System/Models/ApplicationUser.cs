using Microsoft.AspNetCore.Identity;

namespace School_Management_System.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation
        public Student Student { get; set; }
        public Teacher Teacher { get; set; }
        public string Address { get; internal set; }

    }
}
