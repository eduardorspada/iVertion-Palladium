using iVertion.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iVertion.Infra.Data.EntitiesConfiguration
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Acronym)
                   .HasMaxLength(3)
                   .IsRequired();
            builder.Property(t => t.Sequential)
                   .IsRequired();
            builder.Property(t => t.ContractNumber).HasMaxLength(18);
            builder.Property(t => t.AttendantName).HasMaxLength(150);
            builder.HasOne(p => p.Panel)
                   .WithMany(t => t.Tickets)
                   .HasForeignKey(p => p.PanelId);
            builder.HasOne(p => p.PreferenceType)
                   .WithMany(t => t.Tickets)
                   .HasForeignKey(p => p.PreferenceTypeId)
                   .IsRequired();
            builder.HasOne(s => s.ServiceType)
                   .WithMany(t => t.Tickets)
                   .HasForeignKey(s => s.ServiceTypeId)
                   .IsRequired();
            builder.HasOne(c => c.ClientType)
                   .WithMany(t => t.Tickets)
                   .HasForeignKey(c => c.ClientTypeId)
                   .IsRequired();
            builder.HasOne(c => c.Counter)
                   .WithMany(t => t.Tickets)
                   .HasForeignKey(c => c.CounterId);
            builder.HasMany(f => f.TicketFollowUps)
                   .WithOne(t => t.Ticket)
                   .HasForeignKey(f => f.TicketId);
        }
    }
}