using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student_project.Model
{
    public class Students
    {
        [Key]
        [Required]
        [Display(Name = "Номер заліковки")]
        public string ID { get; set; }

        [Display(Name = "Прізвище")]
        public string LastName { get; set; }

        [Display(Name = "Ім'я")]
        public string FirstName { get; set; }

        [Display(Name = "Ім'я по батькові")]
        public string MiddleName { get; set; }

        [Display(Name = "Группа")]
        [ForeignKey("Groups")]
        public string Group { get; set; }

        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public virtual Groups Groups { get; set; }
    }
}
