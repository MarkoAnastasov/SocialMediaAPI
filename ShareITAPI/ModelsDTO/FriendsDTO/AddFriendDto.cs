using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareITAPI.ModelsDTO.FriendsDTO
{
    public class AddFriendDto
    {
        public int UserId { get; set; }
        public int FriendId { get; set; }
    }
}
