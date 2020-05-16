using System;
using System.Collections.Generic;

namespace ShareITAPI.Models
{
    public partial class FriendRequests
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int FromUserId { get; set; }
        public bool Seen { get; set; }
        public virtual Users FromUser { get; set; }
        public virtual Users User { get; set; }
    }
}
