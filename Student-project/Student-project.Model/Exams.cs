﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_project.Model
{
    public class Exams
    {
        [Key]
        public int Key { get; set; }
        [ForeignKey("Subjects")]
        public string Subject { get; set; }
        [ForeignKey("Teachers")]
        public int Teacher { get; set; }
        [ForeignKey("Groups")]
        public string GroupName { get; set; }

        public Subjects Subjects { get; set; }
        public Teachers Teachers { get; set; }
        public Groups Groups { get; set; }

    }
}
