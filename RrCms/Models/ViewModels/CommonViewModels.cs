using System.ComponentModel.DataAnnotations;
using DataAnnotationsExtensions;

namespace RrCms.Models.ViewModels
{
    public class ContacFormViewModel
    {
        [Required]
        [Display(Name = "Ваше имя")]
        [RegularExpression(@"^[А-Яа-я\s]{4,25}$",ErrorMessage = "Имя может включать только символы от А до Я (независимо от регистра)")]
        public string FullName { get; set; }

        [Email(ErrorMessage = "Извините, {0} некорректен.")]
        [Required]
        [Display(Name = "Ваш email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Ваше сообщение")]
        [StringLength(512, ErrorMessage = "{0} должно быть не менее {2} символов.", MinimumLength = 1)]
        public string Message { get; set; }
    }
}