using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student_project.Model
{
    public class Students
    {
        [Key]
        public string ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }

        [ForeignKey("Groups")]
        public string Group { get; set; }
        public string Specialty { get; set; }

        public virtual Groups Groups { get; set; }
    }
}
