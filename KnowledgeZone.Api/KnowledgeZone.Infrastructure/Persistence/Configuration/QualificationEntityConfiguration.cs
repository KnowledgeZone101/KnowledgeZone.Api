using KnowledgeZone.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KnowledgeZone.Infrastructure.Persistence.Configuration
{
    public class QualificationEntityConfiguration : IEntityTypeConfiguration<Qualification>
    {
        public void Configure(EntityTypeBuilder<Qualification> builder)
        {
            builder.ToTable(nameof(Qualification));
            builder.HasKey(q => q.Id);

            builder.Property(q =>q.Name)
                .HasMaxLength(255)
                .IsRequired();

            builder.HasMany(t => t.Teachers)
                .WithOne(q => q.Qualification)
                .HasForeignKey(q => q.QualificationId);
        }
    }
}
