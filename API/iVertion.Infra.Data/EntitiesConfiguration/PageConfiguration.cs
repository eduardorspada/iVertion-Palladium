using iVertion.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iVertion.Infra.Data.EntitiesConfiguration
{
    public class PageConfiguration : IEntityTypeConfiguration<Page>
    {
        public void Configure(EntityTypeBuilder<Page> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Title).HasMaxLength(150).IsRequired();

        }
    }
}