using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_project.Model
{
    public class Subjects
    {
        [Key]
        public string Title { get; set; }
        public int Hours { get; set; }
        public int Credits { get; set; }
    }
}
