using iVertion.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iVertion.Infra.Data.EntitiesConfiguration
{
    public class PanelMerchandisingConfiguration : IEntityTypeConfiguration<PanelMerchandising>
    {
        public void Configure(EntityTypeBuilder<PanelMerchandising> builder)
        {
            builder.HasKey(PM => new {PM.PanelId, PM.MerchandisingId});
        }
    }
}