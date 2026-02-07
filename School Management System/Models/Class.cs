using Microsoft.Build.Tasks.Deployment.Bootstrapper;

namespace School_Management_System.Models
{
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Section { get; set; }
        public int TeacherId { get; set; }


        public required Teacher Teacher { get; set; }
        public required ICollection<Attendance> Attendances { get; set; }
        public required ICollection<ClassEnrollment> ClassEnrollments { get; set; }


    }
}
