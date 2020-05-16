using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Student_project.Model;

namespace Student_project.Repository
{
    public class CDBContext: DbContext
    {
        public CDBContext() : base("UniverDataBase")
        {
            
        }
        public DbSet<Faculties> Faculties { get; set; }
        public DbSet<Students> Students { get; set; }
        public DbSet<Departments> Departments { get; set; }
        public DbSet<Exams> Exams { get; set; }
        public DbSet<Groups> Groups { get; set; }
        public DbSet<Subjects> Subjects { get; set; }
        public DbSet<Teachers> Teachers{ get; set; }
        public DbSet<Marks> Marks { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}
