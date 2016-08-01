using System.ComponentModel.DataAnnotations;

namespace TaskManager.Models.ViewModels
{
    public class LoginModel
    {

        [Required(ErrorMessage = "Введите email")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; } 

    }
}