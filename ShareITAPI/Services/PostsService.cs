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

        public UserPostsDto GetPostById(int id)
        {
            var posts = _postsRepository.GetAllInclude();

            var post = posts.FirstOrDefault(x => x.Id == id);
            var postDto = new UserPostsDto();
            var postList = new List<Posts>();

            if(post == null)
            {
                throw new FlowException("Post not found!");
            }

            postList.Add(post);
            postDto = ModelToDTO.ConvertUserPostsToDTO(postList).FirstOrDefault(x => x.Id == id);

            return postDto;
        }

        public List<UserPostsDto> GetPostsForUser(int id)
        {
            var posts = _postsRepository.GetAllInclude();
            
            var postsForUser = posts.Where(x => x.UserId == id).OrderByDescending(x => x.Id).ToList();

            var userPostsDto = ModelToDTO.ConvertUserPostsToDTO(postsForUser);

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
