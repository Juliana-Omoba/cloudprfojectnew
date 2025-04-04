using Microsoft.EntityFrameworkCore;

namespace StInternships.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Internship> Internships { get; set; }
    }
}
