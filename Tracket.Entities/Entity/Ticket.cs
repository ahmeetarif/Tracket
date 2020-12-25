using System;

namespace Tracket.Entities.Entity
{
    public partial class Ticket
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string SubmitterUserId { get; set; }
        public long ProjectId { get; set; }
        public int PriorityId { get; set; }
        public int StatusId { get; set; }
        public int TypeId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedUserId { get; set; }
        public string SolvedByUserId { get; set; }

        public virtual TicketPriority Priority { get; set; }
        public virtual Project Project { get; set; }
        public virtual TracketUser SolvedByUser { get; set; }
        public virtual TicketStatus Status { get; set; }
        public virtual TracketUser SubmitterUser { get; set; }
        public virtual TicketType Type { get; set; }
        public virtual TracketUser UpdatedUser { get; set; }
    }
}