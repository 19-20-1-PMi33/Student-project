using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student_project.Model
{
    public class Groups
    {
        [Key]
        public string GroupName { get; set; }

        [ForeignKey("Departments")]
        public string Department { get; set; }
        public Departments Departments { get; set; }
    }
}
