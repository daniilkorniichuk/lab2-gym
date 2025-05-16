using System.ComponentModel.DataAnnotations;

namespace lab2_gym.Models
{
    public class Visitor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Прізвище є обов'язковим")]
        [Display(Name = "Прізвище")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Ім'я є обов'язковим")]
        [Display(Name = "Ім'я")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Телефон є обов'язковим")]
        [Phone]
        [Display(Name = "Телефон")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Email є обов'язковим")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        public string FullName => $"{LastName} {FirstName}";
    }
}
