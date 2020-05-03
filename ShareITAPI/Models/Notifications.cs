using System;
using System.Collections.Generic;

namespace ShareITAPI.Models
{
    public partial class Notifications
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public bool ActionType { get; set; }
        public int PostId { get; set; }
        public int FromUsedId { get; set; }

        public virtual Users FromUsed { get; set; }
        public virtual Posts Post { get; set; }
        public virtual Users User { get; set; }
    }
}
