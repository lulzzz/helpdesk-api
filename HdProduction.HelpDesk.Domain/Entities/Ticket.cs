using System.Collections.Generic;

namespace HdProduction.HelpDesk.Domain.Entities
{
  public class Ticket : EntityBase<long>
  {
    public Ticket(string issue, string details, long? assigneeId)
    {
      Issue = issue;
      Details = details;
      AssigneeId = assigneeId;
    }

    public string Issue { get; }
    public string Details { get; }
    public long? AssigneeId { get; }

    public ICollection<Comment> Comments { get; set; } // ef
    public ICollection<TicketAction> Actions { get; set; } // ef
    public ICollection<TicketAttachment> Attachments { get; set; } // ef
  }
}