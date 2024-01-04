using iVertion.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iVertion.Infra.Data.EntitiesConfiguration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Title).HasMaxLength(150).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(25000).IsRequired();
            builder.HasMany(a => a.Articles)
                .WithOne(c => c.Category)
                .HasForeignKey(a => a.CategoryId)
                .IsRequired();
            
            builder.HasData(
                new Category(1, "Uncategorized", "Uncategorized Category", true)
            );
        }
    }
}