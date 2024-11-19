using Microsoft.EntityFrameworkCore;
using StudentDemoForGuid.Models;

namespace StudentDemoForGuid.Data
{
    public class StudentContext:DbContext
    {
        public DbSet<Student> Students { get; set; }

        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {
        }
    }
}
