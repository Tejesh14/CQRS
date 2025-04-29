using Microsoft.EntityFrameworkCore;

namespace CQRS.Models
{
    public class StudentDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public StudentDbContext(DbContextOptions options) : base(options)
        {
            //SeedStudents().Wait();
        }

        private async Task SeedStudents()
        {
            List<Student> students = new List<Student>()
            {
                new Student() {
                    Id = 1,
                    Age = 19,
                    Name = "Tejesh"
                },
                new Student() {
                    Id = 2,
                    Age = 20,
                    Name = "Harsh"
                },
            };

            await Students.AddRangeAsync(students);
        }
    }
}