using Microsoft.AspNetCore.Mvc;
using ShareITAPI.Common.Exceptions;
using ShareITAPI.Interfaces;
using ShareITAPI.ModelsDTO.LikesDTO;
using System;

namespace ShareITAPI.Controllers
{
    [Route("api/likes")]
    [ApiController]
    public class LikesController : ControllerBase
    {
        private readonly ILikesService _likesService;

        public LikesController(ILikesService likesService)
        {
            _likesService = likesService;
        }

        [HttpPost]
        public ActionResult AddLike(AddLikeDto like)
        {
            try
            {
                _likesService.AddLike(like);
            }
            catch (FlowException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500,"An error has occured!Try again later!");
            }

            return CreatedAtAction("AddLike", like);
        }

        [HttpDelete("{userid}/{postid}")]
        public ActionResult DeleteLike(int userId, int postId)
        {
            try
            {
                _likesService.DeleteLike(userId, postId);
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