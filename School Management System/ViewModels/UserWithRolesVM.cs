using School_Management_System.Models;

namespace School_Management_System.ViewModels
{
    public class UserWithRolesVM
    {
        public ApplicationUser User { get; set; }
        public List<string> Roles { get; set; }
    }

}
