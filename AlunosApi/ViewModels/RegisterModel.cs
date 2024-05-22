using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AlunosApi.ViewModels
{
    public class RegisterModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name="Confirma Senha")]
        [Compare("Password", ErrorMessage ="Senhas não correspondem")]
        public string ConfirmPassword { get; set;}
    }
}
