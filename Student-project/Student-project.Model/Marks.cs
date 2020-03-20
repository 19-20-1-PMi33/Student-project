using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_project.Model
{
    public class Marks
    {
        [Key]
        public int ID { get; set; }
        public string Exam { get; set; }
        public int StudentId { get; set; }
        public DateTime Date { get; set; }
    }
}
