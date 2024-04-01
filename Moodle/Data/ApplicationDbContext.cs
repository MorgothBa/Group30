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
        public DbSet<Moodle.Models.Courses> Courses { get; set; } = default!;
    }
}
