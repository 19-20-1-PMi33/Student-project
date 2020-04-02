using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_project.Model
{
    public class Groups
    {
        [Key]
        public string GroupName { get; set; }

        [ForeignKey("Departments")]
        public string Department { get; set; }
        public virtual Departments Departments { get; set; }
    }
}
