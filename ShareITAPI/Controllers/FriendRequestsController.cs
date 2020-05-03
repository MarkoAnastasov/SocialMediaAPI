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
    }
}