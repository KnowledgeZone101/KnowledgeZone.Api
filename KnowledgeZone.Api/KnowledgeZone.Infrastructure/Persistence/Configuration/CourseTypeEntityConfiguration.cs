using KnowledgeZone.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KnowledgeZone.Infrastructure.Persistence.Configuration
{
    public class CourseTypeEntityConfiguration : IEntityTypeConfiguration<CourseType>
    {
        public void Configure(EntityTypeBuilder<CourseType> builder)
        {
            builder.ToTable(nameof(CourseType));
            builder.HasKey(ct => ct.Id);

            builder.Property(ct => ct.Name)
                .HasMaxLength(255)
                .IsRequired();

            builder.HasMany(c => c.Courses)
                .WithOne(ct => ct.CourseType)
                .HasForeignKey(ct => ct.CourseTypeId);
        }
    }
}
