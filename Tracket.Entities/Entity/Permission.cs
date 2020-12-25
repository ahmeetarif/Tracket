using System;

namespace Tracket.Entities.Entity
{
    public partial class Permission
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual UserPermission UserPermission { get; set; }
    }
}