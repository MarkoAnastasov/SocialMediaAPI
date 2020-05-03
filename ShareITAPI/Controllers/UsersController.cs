using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShareITAPI.Common.Exceptions;
using ShareITAPI.Helpers;
using ShareITAPI.Interfaces;
using ShareITAPI.Models;
using ShareITAPI.ModelsDTO;
using ShareITAPI.ModelsDTO.UsersDTO;
using ShareITAPI.Services;

namespace ShareITAPI.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> GetAllUsers()
        {
            var users = _usersService.GetAll();
            if (users == null)
            {
                return NotFound();
            }
            return Ok(users);
        }

        [HttpGet("{id}")]
        public ActionResult<UserDto> GetUserById(int id)
        {
            var targetUser = new UserDto();

            try
            {
                targetUser = _usersService.GetUserById(id, targetUser);
            }
            catch (FlowException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error has occured!Try again later!");
            }

            return Ok(targetUser);
        }

        [HttpGet("{email}/{password}")]
        public ActionResult<AccessToken> UserLogin(string email, string password)
        {
            var accessToken = new AccessToken();

            try
            {
                accessToken = _usersService.UserLogin(email , password, accessToken);
            }
            catch (FlowException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error has occured!Try again later!");
            }

            return Ok(accessToken);
        }

        [HttpGet("access/{accessToken}/{email}")]
        public ActionResult<UserDto> GetByToken(string accessToken, string email)
        {
            var userAccessDto = new UserDto();

            try
            {
                userAccessDto = _usersService.UserAccess(accessToken, email, userAccessDto);
            }
            catch (FlowException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error has occured!Try again later!");
            }

            return userAccessDto;
        }

        [HttpPost]
        public ActionResult<UserDto> RegisterUser(RegisterUserDto user)
        {
            var createdUser = new UserDto();

            try
            {
                _usersService.RegisterUser(user);
                createdUser = _usersService.ReturnCreatedUser(user);
            }
            catch (FlowException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error has occured!Try again later!");
            }

            return CreatedAtAction("RegisterUser", createdUser);
        }

        [HttpPut]
        public ActionResult<UpdateUserDto> UpdateUser(UpdateUserDto user)
        {
            try
            {
               user = _usersService.UpdateUser(user);
            }
            catch (FlowException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error has occured!Try again later!");
            }

            return Ok(user);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            try
            {
                _usersService.DeleteUser(id);
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