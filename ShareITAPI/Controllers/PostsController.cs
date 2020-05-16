using Microsoft.AspNetCore.Mvc;
using ShareITAPI.Common.Exceptions;
using ShareITAPI.Interfaces;
using ShareITAPI.Models;
using ShareITAPI.ModelsDTO;
using System;
using System.Collections.Generic;

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
            try
            {
                var post = _postsService.GetPostById(id);

                return Ok(post);
            }
            catch (FlowException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error has occured!Try again later!");
            }           
        }

        [HttpGet("userid/{id}")]
        public ActionResult<IEnumerable<UserPostsDto>> GetProfilePosts(int id)
        {
            try
            {
                var userPostsDto = _postsService.GetProfilePosts(id);

                return Ok(userPostsDto);
            }
            catch (FlowException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error has occured!Try again later!");
            }            
        }

        [HttpPost("usersid")]
        public ActionResult<IEnumerable<UserPostsDto>> GetPostsForUser(List<int> usersId)
        {
            try
            {
                var userPostsDto = _postsService.GetPostsForUser(usersId);

                return Ok(userPostsDto);
            }
            catch (FlowException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error has occured!Try again later!");
            }
        }

        [HttpPost]
        public ActionResult<Posts> PostPhoto(PostDto post)
        {
            try
            {
                var createdPost = _postsService.AddPost(post);

                return CreatedAtAction("PostPhoto", createdPost);
            }
            catch (FlowException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error has occured!Try again later!");
            }
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