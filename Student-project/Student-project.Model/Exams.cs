using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student_project.Model
{
    public class Exams
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        public int Key { get; set; }
        [ForeignKey("Subjects")]
        public string Subject { get; set; }
        [ForeignKey("Teachers")]
        public int Teacher { get; set; }
        [ForeignKey("Groups")]
        public string GroupName { get; set; }
        public int Year { get; set; }
        public virtual Subjects Subjects { get; set; }
        public virtual Teachers Teachers { get; set; }
        public virtual Groups Groups { get; set; }

    }
}
