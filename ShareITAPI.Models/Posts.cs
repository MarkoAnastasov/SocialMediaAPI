using System;
using System.Collections.Generic;

namespace ShareITAPI.Models
{
    public partial class Posts
    {
        public Posts()
        {
            Comments = new HashSet<Comments>();
            Likes = new HashSet<Likes>();
            Notifications = new HashSet<Notifications>();
        }

        public int Id { get; set; }
        public byte[] PhotoUploaded { get; set; }
        public DateTime TimeUploaded { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }

        public virtual Users User { get; set; }
        public virtual ICollection<Comments> Comments { get; set; }
        public virtual ICollection<Likes> Likes { get; set; }
        public virtual ICollection<Notifications> Notifications { get; set; }
    }
}
