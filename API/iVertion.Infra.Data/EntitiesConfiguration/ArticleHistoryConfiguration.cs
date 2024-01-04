using iVertion.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iVertion.Infra.Data.EntitiesConfiguration
{
    public class ArticleHistoryConfiguration : IEntityTypeConfiguration<ArticleHistory>
    {
        public void Configure(EntityTypeBuilder<ArticleHistory> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Title).HasMaxLength(150).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(25000).IsRequired();
            builder.HasOne(a => a.Article)
                .WithMany(ah => ah.ArticleHistories)
                .HasForeignKey(a => a.ArticleId)
                .IsRequired();
        }
    }
}