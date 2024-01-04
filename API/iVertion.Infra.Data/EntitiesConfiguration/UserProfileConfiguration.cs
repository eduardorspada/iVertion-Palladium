using iVertion.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iVertion.Infra.Data.EntitiesConfiguration
{
    public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Name).HasMaxLength(25).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(150).IsRequired();
            builder.HasMany(r => r.RoleProfiles)
                .WithOne(u => u.UserProfile)
                .HasForeignKey(r => r.UserProfileId)
                .IsRequired();
            
            builder.HasData(
                new UserProfile(1, "Administrator", "This is the default user profile for administrators.", true),
                new UserProfile(2, "Author", "This is the default user profile for authors.", true),
                new UserProfile(3, "Ticketer", "This is the default user profile for tickers.", true),
                new UserProfile(4, "Totem", "This is the default user profile for totens.", true),
                new UserProfile(5, "Users", "This is the default user profile for users.", true)
            );
        }

    }
}