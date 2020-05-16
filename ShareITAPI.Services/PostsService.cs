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

        public Posts AddPost(PostDto postDto)
        {
            if(postDto.PhotoUploaded.Length == 0)
            {
                throw new FlowException("Please choose photo!");
            }
            else if(postDto.Description.Length > 100)
            {
                throw new FlowException("Description length must be max 100 chars!");
            }

            var post = DTOtoModel.PostDTOtoPost(postDto);

            _postsRepository.Add(post);
            _postsRepository.SaveEntities();

            return post;
        }

        public UserPostsDto GetPostById(int id)
        {
            var post = _postsRepository.GetFirstInclude(x => x.Id == id);

            var postList = new List<Posts>();

            if(post == null)
            {
                throw new FlowException("Post not found!");
            }

            postList.Add(post);

            return ModelToDTO.ConvertUserPostsToDTO(postList).FirstOrDefault(x => x.Id == id);
        }

        public List<UserPostsDto> GetProfilePosts(int userId)
        {
            var postsForProfile = _postsRepository.GetWhereInclude(x => x.UserId == userId).OrderByDescending(x => x.Id).ToList();

            if (postsForProfile == null)
            {
                throw new FlowException("Posts not found!");
            }

            return ModelToDTO.ConvertUserPostsToDTO(postsForProfile);
        }

        public List<UserPostsDto> GetPostsForUser(List<int> usersId)
        {
            var postsForUser = new List<Posts>();

            if (postsForUser == null)
            {
                throw new FlowException("Posts not found!");
            }

            foreach (var id in usersId)
            {
                postsForUser.AddRange(_postsRepository.GetWhereInclude(x => x.UserId == id).OrderByDescending(x => x.Id).ToList());
            }
            
            return ModelToDTO.ConvertUserPostsToDTO(postsForUser);
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
