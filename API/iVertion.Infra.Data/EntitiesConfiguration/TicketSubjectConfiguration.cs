using iVertion.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iVertion.Infra.Data.EntitiesConfiguration
{
    public class TicketSubjectConfiguration : IEntityTypeConfiguration<TicketSubject>
    {
        public void Configure(EntityTypeBuilder<TicketSubject> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Name)
                   .HasMaxLength(45)
                   .IsRequired();
            builder.HasMany(f => f.TicketFollowUps)
                   .WithOne(s => s.TicketSubject)
                   .HasForeignKey(f => f.TicketSubjectId)
                   .IsRequired();
        }
    }
}