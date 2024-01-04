using iVertion.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iVertion.Infra.Data.EntitiesConfiguration
{
    public class RoleProfileConfiguration : IEntityTypeConfiguration<RoleProfile>
    {
        public void Configure(EntityTypeBuilder<RoleProfile> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Role).HasMaxLength(25).IsRequired();
            builder.HasOne(u => u.UserProfile)
                .WithMany(r => r.RoleProfiles)
                .HasForeignKey(u => u.UserProfileId)
                .IsRequired();
            
            builder.HasData(
                new RoleProfile(1, "Admin", 1, true),
                new RoleProfile(2, "GetUsers", 1, true),
                new RoleProfile(3, "AddUser", 1, true),
                new RoleProfile(4, "EditUser", 1, true),
                new RoleProfile(5, "RemoveUser", 1, true),
                new RoleProfile(6, "AddToRole", 1, true),
                new RoleProfile(7, "RemoveFromRole", 1, true),
                new RoleProfile(8, "TotemPanel", 1, true),
                new RoleProfile(9, "Manager", 1, true),
                new RoleProfile(10, "Dashboard", 1, true),
                new RoleProfile(11, "Blogger", 1, true),
                new RoleProfile(12, "Ticketer", 1, true),
                new RoleProfile(13, "Traffic", 1, true),
                new RoleProfile(14, "Adsense", 1, true),
                new RoleProfile(15, "ManagerArticles", 1, true),
                new RoleProfile(16, "AddArticle", 1, true),
                new RoleProfile(17, "Blogger", 2, true),
                new RoleProfile(18, "AddArticle", 2, true),
                new RoleProfile(19, "TotemPanel", 3, true),
                new RoleProfile(20, "Ticketer", 3, true),
                new RoleProfile(21, "TotemPanel", 4, true)

            );

        }

    }
}