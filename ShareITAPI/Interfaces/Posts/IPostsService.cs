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

        UserPostsDto GetPostById(int id, UserPostsDto postDto);

        List<UserPostsDto> GetProfilePosts(int userId, List<UserPostsDto> userPostsDto);

        List<UserPostsDto> GetPostsForUser(List<int> usersId, List<UserPostsDto> userPostsDto);

        void DeletePost(int id);
    }
}
