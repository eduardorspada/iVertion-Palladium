using iVertion.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iVertion.Infra.Data.EntitiesConfiguration
{
    public class ClientTypeConfiguration : IEntityTypeConfiguration<ClientType>
    {
        public void Configure(EntityTypeBuilder<ClientType> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Acronym)
                   .HasMaxLength(1)
                   .IsRequired();
            builder.Property(p => p.Description)
                   .HasMaxLength(45)
                   .IsRequired();
            builder.HasMany(t => t.Tickets)
                   .WithOne(c => c.ClientType)
                   .HasForeignKey(t => t.ClientTypeId)
                   .IsRequired();
        }
    }
}