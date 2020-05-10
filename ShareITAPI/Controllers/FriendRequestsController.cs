using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShareITAPI.Common.Exceptions;
using ShareITAPI.Interfaces.FriendRequest;
using ShareITAPI.Models;
using ShareITAPI.ModelsDTO.RequestsDTO;

namespace ShareITAPI.Controllers
{
    [Route("api/friendrequests")]
    [ApiController]
    public class FriendRequestsController : ControllerBase
    {
        private readonly IFriendRequestsService _friendRequestsService;

        public FriendRequestsController(IFriendRequestsService friendRequestsService)
        {
            _friendRequestsService = friendRequestsService;
        }

        [HttpGet("{userid}")]
        public ActionResult<IEnumerable<FriendRequestDto>> GetFriendRequests(int userId)
        {
            try
            {
                var friendRequests = _friendRequestsService.GetRequests(userId);

                return Ok(friendRequests);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error has occured!Try again later!");
            }
        }

        [HttpGet("{userid}/{targetId}")]
        public ActionResult<FriendRequestDto> GetRequestForUser(int userId, int targetId)
        {
            try
            {
                var friendRequestDto = _friendRequestsService.UserRequest(userId,targetId);

                return Ok(friendRequestDto);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error has occured!Try again later!");
            }
        }

        [HttpPost]
        public ActionResult SendRequest(SendRequestDto request)
        {
            try
            {
                _friendRequestsService.SendRequest(request);
            }
            catch (FlowException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error has occured!Try again later!");
            }

            return Ok();
        }

        [HttpPut("{userId}")]
        public ActionResult SeenRequestsForUser(int userId)
        {
            try
            {
                _friendRequestsService.SeenRequests(userId);
            }
            catch (FlowException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error has occured!Try again later!");
            }

            return Ok();
        }

        [HttpDelete("{userid}/{targetId}")]
        public ActionResult CancelRequest(int userId, int targetId)
        {
            try
            {
                _friendRequestsService.CancelFriendRequest(userId, targetId);
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