using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_project.Model
{
    public class Departments
    {
        [Key]
        public string Title { get; set; }
        public string Faculty { get; set; }

    }
}
