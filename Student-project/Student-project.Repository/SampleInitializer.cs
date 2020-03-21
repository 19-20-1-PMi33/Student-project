using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Student_project.Model;

namespace Student_project.Repository
{
    public class SampleInitializer 
        : DropCreateDatabaseIfModelChanges<CDBContext>
    {
        protected override void Seed(CDBContext context)
        {
            List<Students> studensts = new List<Students>
            {
                new Students { ID = 123456, LastName = "Громов", FirstName = "Вадим", MiddleName = "Глібович", Group = "ПМІ-33"},
                new Students { ID = 612345, LastName = "Бобеляк", FirstName = "Тарас", MiddleName = "Степанович", Group = "ПМІ-33" },
                new Students { ID = 561234, LastName = "Чемерський", FirstName = "Влад", MiddleName = "Анатолійович", Group = "ПМІ-33" }
            };

            foreach (Students student in studensts)
                context.Students.Add(student);

            context.SaveChanges();
            base.Seed(context);
        }
    }
}
