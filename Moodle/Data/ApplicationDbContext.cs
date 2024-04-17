using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Moodle.Models;

namespace Moodle.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Moodle.Models.User> User { get; set; } = default!;
        public DbSet<Moodle.Models.Course> Courses { get; set; } = default!;
        /*
        public DbSet<Degrees> Degrees { get; set; }
        public DbSet<Approved_degress> Approved_Degresses { get; set; }
        public DbSet<Events> Events { get; set; }
        public DbSet<Mycourses> Mycourses { get; set; }
        public DbSet<Departments> Departments { get; set; }
        */
    }
}
