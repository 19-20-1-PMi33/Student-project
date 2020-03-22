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
            List<Students> studensts = new List<Students>
                {
                    new Students
                    {
                        ID = "123456c",
                        LastName = "Громов",
                        FirstName = "Вадим",
                        MiddleName = "Глібович",
                        Group = "ПМІ-33"
                    },
                    new Students
                    {
                        ID = "123457c",
                        LastName = "Бобеляк",
                        FirstName = "Тарас",
                        MiddleName = "Степанович",
                        Group = "ПМІ-33"
                    },
                    new Students
                    {
                        ID = "123458c",
                        LastName = "Чемерський",
                        FirstName = "Влад",
                        MiddleName = "Анатолійович",
                        Group = "ПМІ-33"
                    }
                };

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

            foreach (Students student in studensts)
                context.Students.AddOrUpdate(student);

            context.SaveChanges();
            base.Seed(context);
        }
    }
}
