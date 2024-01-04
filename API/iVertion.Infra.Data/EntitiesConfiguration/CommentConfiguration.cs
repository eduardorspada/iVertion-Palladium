using iVertion.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iVertion.Infra.Data.EntitiesConfiguration
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Name).HasMaxLength(500).IsRequired();
            builder.Property(p => p.Body).HasMaxLength(2000).IsRequired();
            builder.HasOne(a => a.Article)
                .WithMany(c => c.Comments)
                .HasForeignKey(a => a.ArticleId)
                .IsRequired();
        }
    }
}