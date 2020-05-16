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
        Posts AddPost(PostDto postDto);

        UserPostsDto GetPostById(int id);

        List<UserPostsDto> GetProfilePosts(int userId);

        List<UserPostsDto> GetPostsForUser(List<int> usersId);

        void DeletePost(int id);
    }
}
