using ShareITAPI.Helpers;
using ShareITAPI.Models;
using ShareITAPI.ModelsDTO;
using ShareITAPI.ModelsDTO.UsersDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareITAPI.Interfaces
{
    public interface IUsersService
    {
        List<UserDto> GetAll();

        UserDto GetUserById(int id);

        void RegisterUser(RegisterUserDto user);

        UserDto ReturnCreatedUser(RegisterUserDto user);

        AccessToken UserLogin(string email , string password);

        UserDto UserAccess(string token, string email);

        UpdateUserDto UpdateUser(UpdateUserDto user);

        void DeleteUser(int id);
    }
}
