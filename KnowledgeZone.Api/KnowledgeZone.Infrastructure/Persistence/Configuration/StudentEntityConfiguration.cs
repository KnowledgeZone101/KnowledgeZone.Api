using KnowledgeZone.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KnowledgeZone.Infrastructure.Persistence.Configuration
{
    public class StudentEntityConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable(nameof(Student));
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(s => s.Email)
                .HasMaxLength(255)
                .IsRequired();

            builder.HasOne(s => s.Enrollment)
                .WithMany(e => e.Students)
                .HasForeignKey(s => s.EnrollmentId);

        }
    }
}
