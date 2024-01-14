using KnowledgeZone.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KnowledgeZone.Infrastructure.Persistence.Configuration
{
    public class TeacherEntityConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.ToTable(nameof(Teacher));
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(t => t.Email)
                .HasMaxLength(255)
                .IsRequired();

            builder.HasMany(c => c.Courses)
                .WithOne(t => t.Teacher)
                .HasForeignKey(t => t.TeacherId);

            builder.HasOne(t => t.Qualification)
                .WithMany(q => q.Teachers)
                .HasForeignKey(t => t.QualificationId);
        }
    }
}
