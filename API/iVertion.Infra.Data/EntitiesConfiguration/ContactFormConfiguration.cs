using iVertion.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iVertion.Infra.Data.EntitiesConfiguration
{
    public class ContactFormConfiguration : IEntityTypeConfiguration<ContactForm>
    {
        public void Configure(EntityTypeBuilder<ContactForm> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Name).HasMaxLength(500).IsRequired();
            builder.Property(p => p.Value).HasMaxLength(500).IsRequired();
            builder.Property(p => p.Url).HasMaxLength(500).IsRequired();
            builder.Property(p => p.Icon).HasMaxLength(500).IsRequired();
        }
    }
}