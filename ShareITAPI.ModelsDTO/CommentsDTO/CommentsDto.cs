using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareITAPI.ModelsDTO.CommentsDTO
{
    public class CommentsDto
    {
        public int Id { get; set; }
        public UserDto User { get; set; }
        public int PostId { get; set; }
        public string Comment { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
