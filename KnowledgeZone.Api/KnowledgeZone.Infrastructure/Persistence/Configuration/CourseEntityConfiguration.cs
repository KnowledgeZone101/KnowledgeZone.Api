using KnowledgeZone.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KnowledgeZone.Infrastructure.Persistence.Configuration
{
    public class CourseEntityConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable(nameof(Course));
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .HasMaxLength(255)
                .IsRequired();

            builder.HasOne(c => c.Teacher)
                .WithMany(t => t.Courses)
                .HasForeignKey(c => c.TeacherId);

            builder.HasOne(c => c.Department)
                .WithMany(d => d.Courses)
                .HasForeignKey(c => c.DepartmentId);

            builder.HasOne(c => c.Enrollment)
                .WithMany(e => e.Courses)
                .HasForeignKey(c => c.EnrollmentId);

            builder.HasOne(c => c.CourseType)
                .WithMany(ct => ct.Courses)
                .HasForeignKey(c => c.CourseTypeId);

            builder.HasMany(l => l.Lessons)
                .WithOne(c => c.Course)
                .HasForeignKey(c => c.CourseId);
        }
    }
}
