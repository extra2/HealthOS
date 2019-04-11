using System;
using System.ComponentModel.DataAnnotations;

namespace HealthOS.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Imię jest zbyt krótkie.", MinimumLength = 2)]
        [Display(Name = "Imię")]
        public string Name { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Nazwisko jest zbyt krótkie.", MinimumLength = 2)]
        [Display(Name = "Nazwisko")]
        public string Surname { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Wybrano niepoprawne dane.", MinimumLength = 1)]
        [Display(Name = "Płeć")]
        public string Gender { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Data urodzenia")]
        public DateTime Birthday { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Hasło jest zbyt krótkie", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Powrórz hasło")]
        [Compare("Password", ErrorMessage = "" +
                                            "Hasło" +
                                            " się nie zgadza")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Jestem lekarzem")]
        public bool isDoctor { get; set; }

        [Required]
        [Display(Name = "Grupa krwi")]
        public string BloodType { get; set; }
    }
}
