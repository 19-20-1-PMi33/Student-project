using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student_project.Model
{
    public class Marks
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        public int ID { get; set; }
        [ForeignKey("Exams")]
        public int Exam { get; set; }
        [ForeignKey("Students")]
        public string StudentId { get; set; }
        public int Mark { get; set; }
        public virtual Exams Exams { get; set; }
        public virtual Students Students { get; set; }

    }
}
