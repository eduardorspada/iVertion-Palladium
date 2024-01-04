using iVertion.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iVertion.Infra.Data.EntitiesConfiguration
{
    public class AddtionalUserRoleConfiguration : IEntityTypeConfiguration<AddtionalUserRole>
    {
        public void Configure(EntityTypeBuilder<AddtionalUserRole> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Role).HasMaxLength(25).IsRequired();
            builder.Property(p => p.TargetUserId).IsRequired();
        }

    }
}