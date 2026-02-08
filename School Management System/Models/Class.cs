
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace School_Management_System.Models
{
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Section { get; set; }
        public int TeacherId { get; set; }

        [ValidateNever]
        public Teacher Teacher { get; set; } = null!;

        public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
        public ICollection<ClassEnrollment> ClassEnrollments { get; set; } = new List<ClassEnrollment>();
    }


}

