using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareITAPI.ModelsDTO.LikesDTO
{
    public class AddLikeDto
    {
        public int UserId { get; set; }
        public int PostId { get; set; }
    }
}
