using iVertion.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iVertion.Infra.Data.EntitiesConfiguration
{
    public class TicketFollowUpConfiguration : IEntityTypeConfiguration<TicketFollowUp>
    {
        public void Configure(EntityTypeBuilder<TicketFollowUp> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Description)
                   .HasMaxLength(250)
                   .IsRequired();
            builder.HasOne(t => t.Ticket)
                   .WithMany(f => f.TicketFollowUps)
                   .HasForeignKey(t => t.TicketId);
            builder.HasOne(s => s.TicketSubject)
                   .WithMany(f => f.TicketFollowUps)
                   .HasForeignKey(s => s.TicketSubjectId)
                   .IsRequired();
        }
    }
}