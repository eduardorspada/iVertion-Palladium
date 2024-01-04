using iVertion.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iVertion.Infra.Data.EntitiesConfiguration
{
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Name).HasMaxLength(150).IsRequired();
            builder.Property(p => p.Url).HasMaxLength(500).IsRequired();
            builder.Property(p => p.Icon).HasMaxLength(500).IsRequired();
            builder.Property(p => p.Level).IsRequired();
        }
    }
}