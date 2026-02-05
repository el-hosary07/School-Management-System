using System.ComponentModel.DataAnnotations;

namespace School_Management_System.ViewModels
{
    public class ResendEmailConfirmationVM
    {
        public int Id { get; set; }

        [Required]
        public string UserNameOREmail { get; set; } = string.Empty;
    }
}
