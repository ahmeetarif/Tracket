using System;

namespace Tracket.Entities.Entity
{
    public partial class UserDetail
    {
        public string UserId { get; set; }
        public string Fullname { get; set; }
        public string ProfilePicturePath { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual TracketUser User { get; set; }
    }
}