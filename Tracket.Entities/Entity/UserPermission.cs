namespace Tracket.Entities.Entity
{
    public partial class UserPermission
    {
        public int PermissionId { get; set; }
        public string UserId { get; set; }

        public virtual Permission Permission { get; set; }
        public virtual TracketUser User { get; set; }
    }
}