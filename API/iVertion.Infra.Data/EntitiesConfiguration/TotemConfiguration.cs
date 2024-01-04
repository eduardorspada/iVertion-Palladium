using iVertion.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iVertion.Infra.Data.EntitiesConfiguration
{
    public class TotemConfiguration : IEntityTypeConfiguration<Totem>
    {
        public void Configure(EntityTypeBuilder<Totem> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Acronym)
                   .HasMaxLength(5)
                   .IsRequired();
            builder.Property(p => p.Name)
                   .HasMaxLength(45)
                   .IsRequired();
            builder.HasMany(p => p.TotemPanels)
                   .WithMany(m => m.Totems);
        }
    }
}