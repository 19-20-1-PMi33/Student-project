using System.ComponentModel.DataAnnotations;

namespace Student_project.Form
{
    public class AuthenticationModel
    {
        [Required(ErrorMessage = "Не вказано логін")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Не вказано пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
