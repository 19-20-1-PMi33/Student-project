using System.ComponentModel.DataAnnotations;

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
