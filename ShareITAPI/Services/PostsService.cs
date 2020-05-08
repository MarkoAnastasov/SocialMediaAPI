using ShareITAPI.Common.Exceptions;
using ShareITAPI.Converters;
using ShareITAPI.Interfaces;
using ShareITAPI.Models;
using ShareITAPI.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareITAPI.Services
{
    public class PostsService : IPostsService
    {

        private readonly IPostsRepository _postsRepository;

        public PostsService(IPostsRepository postsRepository)
        {
            _postsRepository = postsRepository;
        }

        public Posts AddPost(PostDto postDto,Posts post)
        {
            if(postDto.PhotoUploaded.Length == 0)
            {
                throw new FlowException("Please choose photo!");
            }
            else if(postDto.Description.Length > 100)
            {
                throw new FlowException("Description length must be max 100 chars!");
            }

            post = DTOtoModel.PostDTOtoPost(postDto);
            _postsRepository.Add(post);
            _postsRepository.SaveEntities();

            return post;
        }

        public UserPostsDto GetPostById(int id, UserPostsDto postDto)
        {
            var post = _postsRepository.GetFirstInclude(x => x.Id == id);

            var postList = new List<Posts>();

            if(post == null)
            {
                throw new FlowException("Post not found!");
            }

            postList.Add(post);
            postDto = ModelToDTO.ConvertUserPostsToDTO(postList).FirstOrDefault(x => x.Id == id);

            return postDto;
        }

        public List<UserPostsDto> GetProfilePosts(int userId, List<UserPostsDto> userPostsDto)
        {
            var postsForProfile = _postsRepository.GetWhereInclude(x => x.UserId == userId).OrderByDescending(x => x.Id).ToList();

            if (postsForProfile == null)
            {
                throw new FlowException("Posts not found!");
            }

            userPostsDto = ModelToDTO.ConvertUserPostsToDTO(postsForProfile);

            return userPostsDto;
        }

        public List<UserPostsDto> GetPostsForUser(List<int> usersId, List<UserPostsDto> userPostsDto)
        {
            var postsForUser = new List<Posts>();

            foreach (var id in usersId)
            {
                postsForUser.AddRange(_postsRepository.GetWhereInclude(x => x.UserId == id).OrderByDescending(x => x.Id).ToList());
            }

            userPostsDto = ModelToDTO.ConvertUserPostsToDTO(postsForUser);

            if (postsForUser == null)
            {
                throw new FlowException("Posts not found!");
            }
            
            return userPostsDto;
        }

        public void DeletePost(int id)
        {
            var targetPost = _postsRepository.GetById(id);

            if(targetPost == null)
            {
                throw new FlowException("Post not found!");
            }

            _postsRepository.Remove(targetPost);
            _postsRepository.SaveEntities();
        }

    }
}
