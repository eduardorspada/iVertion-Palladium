using iVertion.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iVertion.Infra.Data.EntitiesConfiguration
{
    public class ServiceTypeConfiguration : IEntityTypeConfiguration<ServiceType>
    {
        public void Configure(EntityTypeBuilder<ServiceType> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Acronym)
                   .HasMaxLength(1)
                   .IsRequired();
            builder.Property(p => p.Description)
                   .HasMaxLength(45)
                   .IsRequired();
            builder.HasMany(t => t.Tickets)
                   .WithOne(s => s.ServiceType)
                   .HasForeignKey(t => t.ServiceTypeId)
                   .IsRequired();
        }
    }
}