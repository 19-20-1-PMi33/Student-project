﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_project.Model
{
    public class Departments
    {
        [Key]
        public string Title { get; set; }
        [ForeignKey("Faculties")]
        public string Faculty { get; set; }
        public virtual Faculties Faculties { get; set; }

    }
}
