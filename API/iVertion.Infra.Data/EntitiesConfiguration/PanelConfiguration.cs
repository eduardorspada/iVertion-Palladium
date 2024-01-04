
using iVertion.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iVertion.Infra.Data.EntitiesConfiguration
{
    public class PanelConfiguration : IEntityTypeConfiguration<Panel>
    {
        public void Configure(EntityTypeBuilder<Panel> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Acronym)
                   .HasMaxLength(5)
                   .IsRequired();
            builder.Property(p => p.Name)
                   .HasMaxLength(45)
                   .IsRequired();
            builder.HasMany(t => t.Tickets)
                   .WithOne(p => p.Panel)
                   .HasForeignKey(t => t.PanelId)
                   .IsRequired();
            builder.HasMany(c => c.Counters)
                   .WithOne(p => p.Panel)
                   .HasForeignKey(c => c.PanelId)
                   .IsRequired();
            builder.HasMany(p => p.PanelMerchandisings)
                   .WithMany(m => m.Panels);
            builder.HasMany(p => p.TotemPanels)
                   .WithMany(m => m.Panels);
        }
    }
}