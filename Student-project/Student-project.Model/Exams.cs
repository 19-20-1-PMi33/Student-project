using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_project.Model
{
    public class Exams
    {
        [Key]
        public int Key { get; set; }
        public string Subject { get; set; }
        public string Teacher { get; set; }
        public string GroupName { get; set; }
    }
}
