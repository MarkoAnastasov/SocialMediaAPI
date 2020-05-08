using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShareITAPI.Common.Exceptions;
using ShareITAPI.Interfaces;
using ShareITAPI.Models;
using ShareITAPI.ModelsDTO;

namespace ShareITAPI.Controllers
{
    [Route("api/posts")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostsService _postsService;

        public PostsController(IPostsService postsService)
        {
            _postsService = postsService;
        }

        [HttpGet("{id}")]
        public ActionResult<UserPostsDto> GetPostById(int id)
        {
            var post = new UserPostsDto();

            try
            {
                post = _postsService.GetPostById(id, post);
            }
            catch (FlowException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error has occured!Try again later!");
            }

            return Ok(post);
        }

        [HttpGet("userid/{id}")]
        public ActionResult<IEnumerable<UserPostsDto>> GetProfilePosts(int id)
        {
            var userPostsDto = new List<UserPostsDto>();

            try
            {
                userPostsDto = _postsService.GetProfilePosts(id, userPostsDto);
            }
            catch (FlowException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error has occured!Try again later!");
            }

            return Ok(userPostsDto);
        }

        [HttpPost("usersid")]
        public ActionResult<IEnumerable<UserPostsDto>> GetPostsForUser(List<int> usersId)
        {
            var userPostsDto = new List<UserPostsDto>();

            try
            {
                userPostsDto = _postsService.GetPostsForUser(usersId, userPostsDto);
            }
            catch (FlowException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error has occured!Try again later!");
            }

            return Ok(userPostsDto);
        }

        [HttpPost]
        public ActionResult<Posts> PostPhoto(PostDto post)
        {
            var createdPost = new Posts();

            try
            {
               createdPost = _postsService.AddPost(post,createdPost);
            }
            catch (FlowException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error has occured!Try again later!");
            }

            return CreatedAtAction("PostPhoto", createdPost);
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePost(int id)
        {
            try
            {
                _postsService.DeletePost(id);
            }
            catch (FlowException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error has occured!Try again later!");
            }

            return Ok();
        }
    }
}