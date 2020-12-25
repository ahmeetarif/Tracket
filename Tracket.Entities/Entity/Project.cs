using System;
using System.Collections.Generic;

namespace Tracket.Entities.Entity
{
    public partial class Project
    {
        public Project()
        {
            Tickets = new HashSet<Ticket>();
        }

        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedByUserId { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedUserId { get; set; }

        public virtual TracketUser CreatedByUser { get; set; }
        public virtual TracketUser UpdatedUser { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}