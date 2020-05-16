using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareITAPI.ModelsDTO.FriendsDTO
{
    public class FriendsDto
    {
        public int UserId { get; set; }

        public virtual UserDto Friend { get; set; }
    }
}
