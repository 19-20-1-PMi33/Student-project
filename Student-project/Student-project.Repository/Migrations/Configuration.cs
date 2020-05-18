namespace Student_project.Repository.Migrations
{
    using Student_project.Model;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Student_project.Repository.CDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Student_project.Repository.CDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            List<Faculties> faculties = new List<Faculties>()
            {
                new Faculties
                {
                    Title = "Факультет прикладної математики та інформатики",
                }
            };

            foreach (Faculties faculty in faculties)
            {
                context.Faculties.AddOrUpdate(faculty);
            }

            List<Departments> departments = new List<Departments>
            {
                new Departments
                {
                    Title = "Програмування",
                    Faculty = "Факультет прикладної математики та інформатики",
                },
                new Departments
                {
                    Title = "Інформаційних систем",
                    Faculty = "Факультет прикладної математики та інформатики",
                },
                new Departments
                {
                    Title = "Дискретного аналізу та інтелектуальних систем",
                    Faculty = "Факультет прикладної математики та інформатики",
                }
            };
            foreach (Departments department in departments)
            {
                context.Departments.AddOrUpdate(department);
            }

            List<Groups> groups = new List<Groups>
            {
                new Groups
                {
                    GroupName = "ПМІ-31",
                    Department = "Програмування"
                },
                new Groups
                {
                    GroupName = "ПМІ-32",
                    Department = "Інформаційних систем",
                },
                new Groups
                {
                    GroupName = "ПМІ-33",
                    Department = "Дискретного аналізу та інтелектуальних систем",
                }
            };
            foreach (Groups group in groups)
            {
                context.Groups.AddOrUpdate(group);
            }

            List<Students> studensts = new List<Students>
            {
                new Students
                {
                    ID = "123456c",
                    LastName = "Громов",
                    FirstName = "Вадим",
                    MiddleName = "Глібович",
                    Group = "ПМІ-33",
                    Password = "123456c"
                },
                new Students
                {
                    ID = "123457c",
                    LastName = "Бобеляк",
                    FirstName = "Тарас",
                    MiddleName = "Степанович",
                    Group = "ПМІ-33",
                    Password = "123457c"
                },
                new Students
                {
                    ID = "123458c",
                    LastName = "Чемерський",
                    FirstName = "Влад",
                    MiddleName = "Анатолійович",
                    Group = "ПМІ-33",
                    Password = "123458c"
                }
            };

            foreach (Students student in studensts)
            {
                context.Students.AddOrUpdate(student);
            }

            List<Teachers> teachers = new List<Teachers>
            {
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
                },
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
            };

            foreach (Teachers teacher in teachers)
            {
                if (context.Teachers.Count(x => x.LastName == teacher.LastName && x.FirstName == teacher.FirstName) < 1)
                {
                    context.Teachers.AddOrUpdate(teacher);
                }
            }

            List<Subjects> subjects = new List<Subjects>
            {
                new Subjects
                {
                    Title = "ТІМС",
                    Hours = 120,
                    Credits = 80
                },
                new Subjects
                {
                    Title = "Комп'ютерні інформаційні мережі",
                    Hours = 120,
                    Credits = 80
                }
            };

            foreach (Subjects subject in subjects)
            {
                context.Subjects.AddOrUpdate(subject);
            }

            List<Exams> exams = new List<Exams>
            {
                new Exams
                {
                    Subject = "ТІМС",
                    Teacher = 15,
                    GroupName = "ПМІ-33",
                    Year = 2020
                },
                new Exams
                {
                    Subject = "Комп'ютерні інформаційні мережі",
                    Teacher = 16,
                    GroupName = "ПМІ-33",
                    Year = 2020
                }
            };

            foreach (Exams exam in exams)
            {
                if (context.Exams.Count(x => x.Subject == exam.Subject && x.Teacher == exam.Teacher && x.GroupName == exam.GroupName) < 1)
                {
                    context.Exams.AddOrUpdate(exam);
                }
            }

            List<Marks> marks = new List<Marks>
            {
                new Marks
                {
                    StudentId = "123456c",
                    Exam = 1,
                    Mark = 68
                },
                new Marks
                {
                    StudentId = "123456c",
                    Exam = 2,
                    Mark = 90
                }
            };
            foreach (Marks mark in marks)
            {
                if (context.Marks.Count(x => x.StudentId == mark.StudentId && x.Exam == mark.Exam) < 1)
                {
                    context.Marks.AddOrUpdate(mark);
                }
            }

            Admin admin = new Admin
            {
                Login = "admin",
                Password = "admin"
            };

            context.Admins.AddOrUpdate(admin);

            context.SaveChanges();
            base.Seed(context);
        }
    }
}
