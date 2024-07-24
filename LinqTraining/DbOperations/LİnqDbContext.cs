using LinqTraining.Entities;
using Microsoft.EntityFrameworkCore;

namespace LinqTraining.DbOperations
{
    public class LinqDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("LinqDb");
        }
    }

}