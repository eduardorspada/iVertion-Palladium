using iVertion.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iVertion.Infra.Data.EntitiesConfiguration
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Name).HasMaxLength(500).IsRequired();
            builder.Property(p => p.Phone).HasMaxLength(11).IsRequired();
            builder.Property(p => p.Email).HasMaxLength(250).IsRequired();
            builder.Property(p => p.Subject).HasMaxLength(150).IsRequired();
            builder.Property(p => p.Message).HasMaxLength(5000).IsRequired();
        }
    }
}