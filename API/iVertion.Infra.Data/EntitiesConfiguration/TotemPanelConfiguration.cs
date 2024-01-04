
using iVertion.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iVertion.Infra.Data.EntitiesConfiguration
{
    public class TotemPanelConfiguration : IEntityTypeConfiguration<TotemPanel>
    {
        public void Configure(EntityTypeBuilder<TotemPanel> builder)
        {
            
            builder.HasKey(TP => new {TP.PanelId, TP.TotemId});
        }
    }
}