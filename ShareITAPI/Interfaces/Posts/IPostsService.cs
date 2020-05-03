using ShareITAPI.Models;
using ShareITAPI.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareITAPI.Interfaces
{
    public interface IPostsService
    {
        Posts AddPost(PostDto postDto, Posts post);

        UserPostsDto GetPostById(int id);

        List<UserPostsDto> GetPostsForUser(int id);

        void DeletePost(int id);
    }
}
