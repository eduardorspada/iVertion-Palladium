using iVertion.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iVertion.Infra.Data.EntitiesConfiguration
{
    public class AdditionalUserRoleConfiguration : IEntityTypeConfiguration<AdditionalUserRole>
    {
        public void Configure(EntityTypeBuilder<AdditionalUserRole> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Role).HasMaxLength(25).IsRequired();
            builder.Property(p => p.TargetUserId).IsRequired();
        }

    }
}