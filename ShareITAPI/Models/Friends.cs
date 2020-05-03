using System;
using System.Collections.Generic;

namespace ShareITAPI.Models
{
    public partial class Friends
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int FriendId { get; set; }

        public virtual Users Friend { get; set; }
        public virtual Users User { get; set; }
    }
}
