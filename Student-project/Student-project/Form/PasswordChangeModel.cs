using System.ComponentModel.DataAnnotations;

namespace Student_project.Form
{
    public class PasswordChangeModel
    {

        [Required(ErrorMessage = "Не вказано пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Не вказано пароль")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Паролі не співпадають")]
        public string ConfirmNewPassword { get; set; }
    }
}
