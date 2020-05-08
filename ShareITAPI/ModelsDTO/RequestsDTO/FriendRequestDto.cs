using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareITAPI.ModelsDTO.RequestsDTO
{
    public class FriendRequestDto
    {
        public int Id { get; set; }
        public UserDto FromUser { get; set; }
        public int ToUserId { get; set; }
        public bool Seen { get; set; }
    }
}
