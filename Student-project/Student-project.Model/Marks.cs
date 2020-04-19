using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_project.Model
{
    public class Marks
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Exams")]
        public int Exam { get; set; }
        [ForeignKey("Students")]
        public string StudentId { get; set; }
        public DateTime Date { get; set; }
        public int Mark { get; set; }
        public Exams Exams { get; set; }
        public Students Students { get; set; }

    }
}
