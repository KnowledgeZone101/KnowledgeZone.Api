using KnowledgeZone.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeZone.Infrastructure
{
    public class KnowledgeZoneDbContext : DbContext
    {
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseType> CourseTypes { get; set; }
        public DbSet<Department> Departments { get; set; }  
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        public KnowledgeZoneDbContext(DbContextOptions<KnowledgeZoneDbContext> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(KnowledgeZoneDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

    }
}
