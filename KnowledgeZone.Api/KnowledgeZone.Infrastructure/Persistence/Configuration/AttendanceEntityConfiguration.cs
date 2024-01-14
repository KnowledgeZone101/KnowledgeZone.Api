using KnowledgeZone.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KnowledgeZone.Infrastructure.Persistence.Configuration
{
    public class AttendanceEntityConfiguration : IEntityTypeConfiguration<Attendance>
    {
        public void Configure(EntityTypeBuilder<Attendance> builder)
        {
            builder.ToTable(nameof(Attendance));
            builder.HasKey(a => a.Id);

            builder.Property(a => a.StudentId)
                .IsRequired();

            builder.HasOne(a => a.Lesson)
                .WithOne(l => l.Attendance)
                .HasForeignKey<Attendance>(a => a.LessonId);

            builder.Property(a => a.AttendanceType)
                .IsRequired();

            builder.Property(a => a.Mark)
                .IsRequired(false);
        }
    }
}
