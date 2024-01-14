using KnowledgeZone.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KnowledgeZone.Infrastructure.Persistence.Configuration
{
    public class RoomEntityConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.ToTable(nameof(Room));
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Name)
                .HasMaxLength(255)
                .IsRequired();

            builder.HasMany(l => l.Lessons)
                .WithOne(r => r.Room)
                .HasForeignKey(r => r.RoomId);
        }
    }
}
