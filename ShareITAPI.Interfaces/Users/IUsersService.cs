using ShareITAPI.Helpers;
using ShareITAPI.ModelsDTO;
using ShareITAPI.ModelsDTO.UsersDTO;
using System.Collections.Generic;

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
