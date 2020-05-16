using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareITAPI.ModelsDTO.CommentsDTO
{
    public class AddCommentDto
    {
        public int UserId { get; set; }
        public int PostId { get; set; }
        public string Comment { get; set; }
    }
}
