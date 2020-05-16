using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareITAPI.ModelsDTO
{
    public class LikesDto
    {
        public UserDto User { get; set; }
        public int PostId { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
