using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_project.Model
{
    public class Groups
    {
        [Key]
        public string GroupName { get; set; }
        public string Department { get; set; }
    }
}
