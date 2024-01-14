using KnowledgeZone.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KnowledgeZone.Infrastructure.Persistence.Configuration
{
    public class LessonEntityConfiguration : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.ToTable(nameof(Lesson));
            builder.HasKey(l => l.Id);

            builder.HasOne(l => l.Room)
                .WithMany(r => r.Lessons)
                .HasForeignKey(l => l.RoomId);

            builder.HasOne(l => l.Courses)
                .WithMany(r => r.Lessons)
                .HasForeignKey(l => l.CourseId);

            builder.HasOne(l => l.Attendance)
                .WithOne(r => r.Lessons)
                .HasForeignKey<Lesson>(l => l.AttendanceId);
        }
    }
}
