using Microsoft.EntityFrameworkCore;
using MoodleAPI.Models;
using MoodleAPI;

namespace MoodleAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Degree> Degrees { get; set; }
        public DbSet<MyCourse> MyCourses { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<ApprovedDegree> ApprovedDegrees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.MyCourses)
                .WithOne(mc => mc.User)
                .HasForeignKey(mc => mc.UserId);
            modelBuilder.Entity<Course>()
                .HasMany(c => c.MyCourses)
                .WithOne(mc => mc.Course)
                .HasForeignKey(mc => mc.CourseId);
            // Configure the relationship for User and Degree
            modelBuilder.Entity<User>()
                .HasOne(d => d.Degree)
                .WithMany(u => u.Users)
                .HasForeignKey(u => u.DegreeId);
            // Configure the relationship for Course and Event
            modelBuilder.Entity<Course>()
                .HasMany(c => c.Events)
                .WithOne(e => e.Course)
                .HasForeignKey(e => e.CourseId);
            // Configure the many-to-many relationship between Course and Degree through ApprovedDegrees
            modelBuilder.Entity<ApprovedDegree>()
                .HasOne(ad => ad.Course)
                .WithMany(c => c.ApprovedDegrees)
                .HasForeignKey(ad => ad.CourseId);
            modelBuilder.Entity<ApprovedDegree>()
                .HasOne(ad => ad.Degree)
                .WithMany(d => d.ApprovedDegrees)
                .HasForeignKey(ad => ad.DegreeId);
        }
    }
}
