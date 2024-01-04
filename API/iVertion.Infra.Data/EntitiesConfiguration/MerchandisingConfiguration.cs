using iVertion.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iVertion.Infra.Data.EntitiesConfiguration
{
    public class MerchandisingConfiguration : IEntityTypeConfiguration<Merchandising>
    {
        public void Configure(EntityTypeBuilder<Merchandising> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Name)
                   .HasMaxLength(45)
                   .IsRequired();
            builder.Property(p => p.Description)
                   .HasMaxLength(250)
                   .IsRequired();
            builder.Property(p => p.Image)
                   .HasMaxLength(250)
                   .IsRequired();
            builder.HasOne(p => p.PanelMerchandising)
                   .WithMany(m => m.Merchandisings);
        }
    }
}