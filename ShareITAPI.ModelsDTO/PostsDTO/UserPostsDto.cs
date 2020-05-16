using ShareITAPI.ModelsDTO.CommentsDTO;
using System;
using System.Collections.Generic;

namespace ShareITAPI.ModelsDTO
{
    public class UserPostsDto
    {
        public UserPostsDto()
        {
            Comments = new List<CommentsDto>();
            Likes = new List<LikesDto>();
        }

        public int Id { get; set; }
        public byte[] PhotoUploaded { get; set; }
        public DateTime TimeUploaded { get; set; }
        public string Description { get; set; }

        public virtual ICollection<CommentsDto> Comments { get; set; }
        public virtual ICollection<LikesDto> Likes { get; set; }
        public virtual UserDto User { get; set; } = new UserDto();
       
    }
}
