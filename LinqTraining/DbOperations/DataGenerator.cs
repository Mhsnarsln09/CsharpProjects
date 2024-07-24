using LinqTraining.Entities;

namespace LinqTraining.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize()
        {
            using (var context = new LinqDbContext())
            {
                if (context.Students.Any())
                {
                    return;
                }

                context.Students.AddRange(
                    new Student { Name = "Ali", Surname = "Yılmaz", ClassId = 1 },
                    new Student { Name = "Veli", Surname = "Korkmaz", ClassId = 1 },
                    new Student { Name = "Ayşe", Surname = "Can", ClassId = 2 },
                    new Student { Name = "Fatma", Surname = "Yılmaz", ClassId = 2 }
                );

                context.SaveChanges();
            }
        }
    }
}