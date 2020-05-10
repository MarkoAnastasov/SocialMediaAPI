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
            try
            {
                var targetUser = _usersService.GetUserById(id);

                return Ok(targetUser);
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

        [HttpGet("{email}/{password}")]
        public ActionResult<AccessToken> UserLogin(string email, string password)
        {
            try
            {
                var accessToken = _usersService.UserLogin(email , password);

                return Ok(accessToken);
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

        [HttpGet("access/{accessToken}/{email}")]
        public ActionResult<UserDto> GetByToken(string accessToken, string email)
        {
            try
            {
                var userAccessDto = _usersService.UserAccess(accessToken, email);

                return Ok(userAccessDto);
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
        public ActionResult<UserDto> RegisterUser(RegisterUserDto user)
        {
            try
            {
                _usersService.RegisterUser(user);
                var createdUser = _usersService.ReturnCreatedUser(user);

                return CreatedAtAction("RegisterUser", createdUser);
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