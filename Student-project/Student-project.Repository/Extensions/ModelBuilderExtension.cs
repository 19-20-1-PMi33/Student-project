using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student_project.Model;

namespace Student_project.Repository.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            SeedFaculties(modelBuilder);
            SeedDepartments(modelBuilder);
            SeedGroups(modelBuilder);
            SeedStudents(modelBuilder);
            SeedTeachers(modelBuilder);
            SeedSubjects(modelBuilder);
            SeedExams(modelBuilder);
            SeedMarks(modelBuilder);
            SeedAdmins(modelBuilder);
        }
        public static void SeedFaculties(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Faculties>().HasData(
                new Faculties
                {
                    Title = "Факультет прикладної математики та інформатики",
                }
            );
            modelBuilder.Entity<Faculties>().HasData(
                new Faculties
                {
                    Title = "Економічний факультет",
                }
            );
        }
        public static void SeedDepartments(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Departments>().HasData(
                new Departments
                {
                    Title = "Програмування",
                    Faculty = "Факультет прикладної математики та інформатики",
                }
            );
            modelBuilder.Entity<Departments>().HasData(
                new Departments
                {
                    Title = "Інформаційних систем",
                    Faculty = "Факультет прикладної математики та інформатики",
                }
            );
            modelBuilder.Entity<Departments>().HasData(
                new Departments
                {
                    Title = "Дискретного аналізу та інтелектуальних систем",
                    Faculty = "Факультет прикладної математики та інформатики",
                }
            );
        }
        public static void SeedGroups(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Groups>().HasData(
                new Groups
                {
                    GroupName = "ПМІ-31",
                    Department = "Програмування"
                }
            );
            modelBuilder.Entity<Groups>().HasData(
                new Groups
                {
                    GroupName = "ПМІ-32",
                    Department = "Інформаційних систем"
                }
            );
            modelBuilder.Entity<Groups>().HasData(
                new Groups
                {
                    GroupName = "ПМІ-33",
                    Department = "Дискретного аналізу та інтелектуальних систем",
                }
            );
        }
        public static void SeedStudents(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Students>().HasData(
                new Students
                {
                    ID = "123456c",
                    LastName = "Громов",
                    FirstName = "Вадим",
                    MiddleName = "Глібович",
                    Group = "ПМІ-33",
                    Password = "123456c"
                }
            );
            modelBuilder.Entity<Students>().HasData(
                new Students
                {
                    ID = "123457c",
                    LastName = "Бобеляк",
                    FirstName = "Тарас",
                    MiddleName = "Степанович",
                    Group = "ПМІ-33",
                    Password = "123457c"
                }
            );
        }
        public static void SeedTeachers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teachers>().HasData(
                new Teachers
                {
                    ID = 1,
                    LastName = "Притула",
                    FirstName = "Микола",
                    MiddleName = "Миколайович",
                    Department = "Дискретного аналізу та інтелектуальних систем",
                    Type = "Професор",
                    Email = "prytula@gmail.com",
                    Password = "prytula@gmail.com"
                }
            );
            modelBuilder.Entity<Teachers>().HasData(
                new Teachers
                {
                    ID = 2,
                    LastName = "Рикалюк",
                    FirstName = "Роман",
                    MiddleName = "Євстахович",
                    Department = "Програмування",
                    Type = "Доцент",
                    Email = "rykaluk@gmail.com",
                    Password = "rykaluk@gmail.com"
                }
            );
        }
        public static void SeedSubjects(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Subjects>().HasData(
                new Subjects
                {
                    Title = "ТІМС",
                    Hours = 120,
                    Credits = 80
                }
            );
            modelBuilder.Entity<Subjects>().HasData(
                new Subjects
                {
                    Title = "Комп'ютерні інформаційні мережі",
                    Hours = 120,
                    Credits = 80
                }
            );
        }
        public static void SeedExams(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exams>().HasData(
                new Exams
                {
                    Key = 1,
                    Subject = "ТІМС",
                    Teacher = 15,
                    GroupName = "ПМІ-33",
                    Year = 2020
                }
            );
            modelBuilder.Entity<Exams>().HasData(
                new Exams
                {
                    Key = 2,
                    Subject = "Комп'ютерні інформаційні мережі",
                    Teacher = 16,
                    GroupName = "ПМІ-33",
                    Year = 2020
                }
            ) ;
        }
        public static void SeedMarks(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Marks>().HasData(
                new Marks
                {
                    StudentId = "123456c",
                    Date = new DateTime(2019, 12, 26).Date,
                    Exam = 1,
                    Mark = 68
                }
            );
            modelBuilder.Entity<Marks>().HasData(
                new Marks
                {
                    StudentId = "123456c",
                    Date = new DateTime(2019, 12, 29).Date,
                    Exam = 2,
                    Mark = 90
                }
            );
        }
        public static void SeedAdmins(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>().HasData(
                new Admin
                {
                    Login = "admin",
                    Password = "admin"
                }
            ); 
        }
    }
}
