using System.ComponentModel.DataAnnotations;

namespace Student_project.Model
{
    public class Admin
    {
        [Key]
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
