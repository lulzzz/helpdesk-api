using HdProduction.HelpDesk.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HdProduction.HelpDesk.Infrastructure.EfConfigurations
{
  public class TicketConfiguration : EntityBaseConfiguration<Ticket, long>
  {
    protected override void ConfigureNext(EntityTypeBuilder<Ticket> builder)
    {
      builder.Property(t => t.Issue)
        .IsRequired()
        .HasMaxLength(256);

      builder.HasOne(e => e.Assignee)
        .WithMany(e => e.Tickets);

      builder.Property(t => t.Details)
        .IsRequired();

      builder.Property(t => t.AssigneeId);
      builder.Property(t => t.IssuerEmail);

      builder.HasOne(t => t.Status)
        .WithMany()
        .HasForeignKey(t => t.StatusId);

      builder.HasOne(t => t.Priority)
        .WithMany()
        .HasForeignKey(t => t.PriorityId);
      
      builder.HasOne(t => t.Category)
        .WithMany()
        .HasForeignKey(t => t.CategoryId);

      base.ConfigureNext(builder);
    }
  }
}