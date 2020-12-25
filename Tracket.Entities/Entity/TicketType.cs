using System;
using System.Collections.Generic;

namespace Tracket.Entities.Entity
{
    public partial class TicketType
    {
        public TicketType()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedUserId { get; set; }

        public virtual TracketUser CreatedUser { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}