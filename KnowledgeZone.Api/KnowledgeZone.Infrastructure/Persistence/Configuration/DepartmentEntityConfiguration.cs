using KnowledgeZone.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KnowledgeZone.Infrastructure.Persistence.Configuration
{
    public class DepartmentEntityConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable(nameof(Department));
            builder.HasKey(d => d.Id);

            builder.Property(d => d.Name)
                .HasMaxLength(255)
                .IsRequired();

            builder.HasMany(c => c.Courses)
                .WithOne(d => d.Department)
                .HasForeignKey(d => d.DepartmentId);
        }
    }
}
