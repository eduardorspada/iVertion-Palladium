using iVertion.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iVertion.Infra.Data.EntitiesConfiguration
{
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Title).HasMaxLength(150).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(25000).IsRequired();
            builder.HasOne(c => c.Category)
                .WithMany(a => a.Articles)
                .HasForeignKey(c => c.CategoryId)
                .IsRequired();
            builder.HasMany(ah => ah.ArticleHistories)
                .WithOne(a => a.Article)
                .HasForeignKey(a => a.ArticleId);
            
        }
    }
}