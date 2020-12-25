using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Tracket.Entities.Entity
{
    public class TracketUser : IdentityUser
    {
        public TracketUser()
        {
            ProjectCreatedByUsers = new HashSet<Project>();
            ProjectUpdatedUsers = new HashSet<Project>();
            TicketPriorities = new HashSet<TicketPriority>();
            TicketSolvedByUsers = new HashSet<Ticket>();
            TicketStatuses = new HashSet<TicketStatus>();
            TicketSubmitterUsers = new HashSet<Ticket>();
            TicketTypes = new HashSet<TicketType>();
            TicketUpdatedUsers = new HashSet<Ticket>();
            UserPermissions = new HashSet<UserPermission>();
        }

        public virtual UserDetail UserDetail { get; set; }
        public virtual ICollection<Project> ProjectCreatedByUsers { get; set; }
        public virtual ICollection<Project> ProjectUpdatedUsers { get; set; }
        public virtual ICollection<TicketPriority> TicketPriorities { get; set; }
        public virtual ICollection<Ticket> TicketSolvedByUsers { get; set; }
        public virtual ICollection<TicketStatus> TicketStatuses { get; set; }
        public virtual ICollection<Ticket> TicketSubmitterUsers { get; set; }
        public virtual ICollection<TicketType> TicketTypes { get; set; }
        public virtual ICollection<Ticket> TicketUpdatedUsers { get; set; }
        public virtual ICollection<UserPermission> UserPermissions { get; set; }
    }
}