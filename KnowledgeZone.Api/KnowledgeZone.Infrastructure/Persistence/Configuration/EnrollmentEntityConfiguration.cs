using KnowledgeZone.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KnowledgeZone.Infrastructure.Persistence.Configuration
{
    public class EnrollmentEntityConfiguration : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.ToTable(nameof(Enrollment));
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .HasMaxLength(255)
                .IsRequired();

            //builder.HasMany(s => s.Students)
            //    .WithOne(e => e.Enrollment);

            builder.HasMany(c => c.Courses)
                .WithOne(e => e.Enrollment)
                .HasForeignKey(e => e.EnrollmentId);
        }
    }
}
