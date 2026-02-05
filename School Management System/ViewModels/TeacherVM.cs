using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace School_Management_System.ViewModels
{
    public class TeacherVM
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime JoiningDate { get; set; }

        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public List<int> SelectedSubjects { get; set; }
        public IEnumerable<SelectListItem> SubjectList { get; set; }

        public IFormFile Image { get; set; }
        public IFormFile? ImageFile { get; set; }

    }

}
