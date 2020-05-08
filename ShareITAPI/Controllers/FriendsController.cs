using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShareITAPI.Common.Exceptions;
using ShareITAPI.Interfaces.FriendsInterface;
using ShareITAPI.ModelsDTO.FriendsDTO;

namespace ShareITAPI.Controllers
{
    [Route("api/friends")]
    [ApiController]
    public class FriendsController : ControllerBase
    {
        private readonly IFriendsService _friendsService;

        public FriendsController(IFriendsService friendsService)
        {
            _friendsService = friendsService;
        }

        [HttpGet("{userid}")]
        public ActionResult<IEnumerable<FriendsDto>> GetFriendsForUser(int userId)
        {
            var friendsDto = new List<FriendsDto>();

            try
            {
                friendsDto = _friendsService.GetFriendsForUser(userId, friendsDto);
            }
            catch (FlowException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error has occured!Try again later!");
            }

            return Ok(friendsDto);
        }

        [HttpGet("{userid}/{targetId}")]
        public ActionResult<FriendsDto> CheckFriend(int userId, int targetId)
        {
            var friendDto = new FriendsDto();

            try
            {
                friendDto = _friendsService.CheckIfFriend(userId, targetId, friendDto);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error has occured!Try again later!");
            }

            return Ok(friendDto);
        }

        [HttpPost]
        public ActionResult AddFriend(AddFriendDto addFriend)
        {
            try
            {
                _friendsService.AcceptFriendRequest(addFriend);
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
        public ActionResult RemoveFriend(int userId, int targetId)
        {
            try
            {
                _friendsService.RemoveFriendship(userId, targetId);
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