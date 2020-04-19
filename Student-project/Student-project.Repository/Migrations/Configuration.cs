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
                    Specialty = "Комп'ютерні науки",
                    Password = "123456c"
                },
                new Students
                {
                    ID = "123457c",
                    LastName = "Бобеляк",
                    FirstName = "Тарас",
                    MiddleName = "Степанович",
                    Group = "ПМІ-33",
                    Specialty = "Комп'ютерні науки",
                    Password = "123457c"
                },
                new Students
                {
                    ID = "123458c",
                    LastName = "Чемерський",
                    FirstName = "Влад",
                    MiddleName = "Анатолійович",
                    Group = "ПМІ-33",
                    Specialty = "Комп'ютерні науки",
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
                    LastName = "Притула",
                    FirstName = "Микола",
                    MiddleName = "Миколайович",
                    Department = "Дискретного аналізу та інтелектуальних систем",
                    Type = "Професор"
                },
                new Teachers
                {
                    LastName = "Рикалюк",
                    FirstName = "Роман",
                    MiddleName = "Євстахович",
                    Department = "Програмування",
                    Type = "Доцент"
                }
            };

            foreach (Teachers teacher in teachers)
            {
                context.Teachers.AddOrUpdate(teacher);
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
                    Teacher = 1,
                    GroupName = "ПМІ-33"
                },
                new Exams
                {
                    Subject = "Комп'ютерні інформаційні мережі",
                    Teacher = 2,
                    GroupName = "ПМІ-33"
                }
            };

            foreach (Exams exam in exams)
            {
                context.Exams.AddOrUpdate(exam);
            }

            List<Marks> marks = new List<Marks>
            {
                new Marks
                {
                    Exam = 1,
                    StudentId = "123456c",
                    Date = new DateTime(2019,12,26).Date,
                    Mark = 68
                },
                new Marks
                {
                    Exam = 2,
                    StudentId = "123456c",
                    Date = new DateTime(2019,12,29).Date,
                    Mark = 90
                }
            };
            foreach (Marks mark in marks)
            {
                context.Marks.AddOrUpdate(mark);
               
            }
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
