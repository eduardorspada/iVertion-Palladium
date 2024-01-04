using iVertion.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iVertion.Infra.Data.EntitiesConfiguration
{
    public class CounterConfiguration : IEntityTypeConfiguration<Counter>
    {
        public void Configure(EntityTypeBuilder<Counter> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Name)
                   .HasMaxLength(5)
                   .IsRequired();
            builder.HasOne(p => p.Panel)
                   .WithMany(c => c.Counters)
                   .HasForeignKey(c => c.PanelId)
                   .IsRequired();
            builder.HasMany(t => t.Tickets)
                   .WithOne(c => c.Counter)
                   .HasForeignKey(t => t.CounterId);
        }
    }
}