using ShareITAPI.Common.Exceptions;
using ShareITAPI.Converters;
using ShareITAPI.Helpers;
using ShareITAPI.Interfaces;
using ShareITAPI.Models;
using ShareITAPI.ModelsDTO;
using ShareITAPI.ModelsDTO.UsersDTO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ShareITAPI.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public List<UserDto> GetAll()
        {
            var users = _usersRepository.GetAll();
            return ModelToDTO.ConvertUsersToDto(users);
        }

        public UserDto GetUserById(int id,UserDto targetUser)
        {
            var requestedUser = _usersRepository.GetById(id);

            if(targetUser == null)
            {
                throw new FlowException("User not found!");
            }

            targetUser = ModelToDTO.ConvertSingleUserToDto(requestedUser);

            return targetUser;
        }

        public void RegisterUser(RegisterUserDto user)
        {
            var users = _usersRepository.GetAll();

            var existingUser = users.FirstOrDefault(x => x.Email.ToLower().Trim() == user.Email.ToLower().Trim());
            if(existingUser != null)
            {
                throw new FlowException("User with this e-mail already exists!");
            }

            ValidateEmail(user);
            ValidateBirthday(user);
            ValidatePassword(user);

            var newUser = DTOtoModel.DtoToUserRegistration(user);
            _usersRepository.Add(newUser);
            _usersRepository.SaveEntities();
        }

        public UserDto ReturnCreatedUser(RegisterUserDto user)
        {
            var users = _usersRepository.GetAll();
            var createdUser = users.FirstOrDefault(x => x.Email == user.Email);
            var usersList = new List<Users>() { createdUser };
            var usersDto = ModelToDTO.ConvertUsersToDto(usersList);
            var createdUserDto = usersDto.FirstOrDefault(x => x.Id == createdUser.Id);

            return createdUserDto;
        }

        public AccessToken UserLogin(string email, string password, AccessToken accessToken)
        {
            var users = _usersRepository.GetAll();
            var requestedUser = users.FirstOrDefault(x => x.Email.ToLower().Trim() == email.ToLower().Trim() && x.Password == password);
            if(requestedUser == null)
            {
                throw new FlowException("Incorrect e-mail or password!");
            }

            accessToken.Value = GenerateAccessToken();
            requestedUser.AccessToken = accessToken.Value;
            requestedUser.IsOnline = true;
            _usersRepository.SaveEntities();

            return accessToken;
        }

        public UserDto UserAccess(string token,string email, UserDto accessUserDto)
        {
            var users = _usersRepository.GetAll();
            var requestedUser = users.FirstOrDefault(x => x.AccessToken == token && x.Email == email);
            var usersList = new List<Users>() { requestedUser };
            
            if (requestedUser == null)
            {
                throw new FlowException("User not found!");
            }

            var usersDto = ModelToDTO.ConvertUsersToDto(usersList);
            accessUserDto = usersDto.FirstOrDefault(x => x.Id == requestedUser.Id);

            return accessUserDto;
        }

        public UpdateUserDto UpdateUser(UpdateUserDto user)
        {
            var targetUser = _usersRepository.GetById(user.Id);

            if (targetUser == null)
            {
                throw new FlowException("User not found!");
            }

            if (user.ProfilePicture != "")
            {
                targetUser.ProfilePicture = Convert.FromBase64String(user.ProfilePicture);
            }

            ValidateUpdatePassword(user, targetUser);
            ValidateUpdateName(user, targetUser);

            _usersRepository.Update(targetUser);
            _usersRepository.SaveEntities();

            return user;
        }

        public void DeleteUser(int id)
        {
            var targetUser = _usersRepository.GetById(id);

            if(targetUser == null)
            {
                throw new FlowException("User not found!");
            }

            _usersRepository.Remove(targetUser);
            _usersRepository.SaveEntities();
        }

        private static void ValidateUpdateName(UpdateUserDto user, Users targetUser)
        {
            if (user.FullName.Length != 0)
            {
                var firstName = user.FullName.Trim().Split(' ').First();
                var lastName = user.FullName.Trim().Split(' ').Last();
                if(firstName != lastName && firstName.Length > 2 && lastName.Length > 3 && firstName.Length < 20 && lastName.Length < 20)
                {
                    targetUser.Name = firstName;
                    targetUser.Surname = lastName;
                    targetUser.IsPrivate = user.IsPrivate;
                }
                else
                {
                    throw new FlowException("Invalid full name!");
                }
            }
            else
            {
                throw new FlowException("Please enter full name!");
            }
        }

        private static void ValidateUpdatePassword(UpdateUserDto user, Users targetUser)
        {
            if (user.OldPassword.Length != 0)
            {
                if (user.OldPassword == targetUser.Password)
                {
                    if (user.NewPassword == user.ConfNewPass && (user.NewPassword.Length >= 8 && user.ConfNewPass.Length >= 8))
                    {
                        targetUser.Password = user.NewPassword;
                    }
                    else
                    {
                        throw new FlowException("Check your matching passwords!");
                    }
                }
                else
                {
                    throw new FlowException("Incorrect old password!");
                }
            }
        }

        private static string GenerateAccessToken()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[20];
            var random = new Random();
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            var accessToken = new string(stringChars);
            return accessToken;
        }

        private static void ValidateEmail(RegisterUserDto user)
        {
            var atpos = user.Email.Trim().IndexOf("@");
            var dotpos = user.Email.Trim().LastIndexOf(".");
            if (atpos < 1 || (dotpos - atpos < 2))
            {
                throw new FlowException("Please enter valid e-mail!");
            }
        }

        private static void ValidateBirthday(RegisterUserDto user)
        {
            var today = DateTime.Today;
            var age = today - user.DateOfBirth;
            if((age.TotalMilliseconds / 31557600000) < 16)
            {
                throw new FlowException("You need to be atleast 16 years old!");
            }
        }

        private static void ValidatePassword(RegisterUserDto user)
        {
            if(user.Password.Length < 8 || user.Password.Length > 20)
            {
                throw new FlowException("Enter a password between 8 and 20 characters!");
            }
            else if (user.Name.Length > 20 || user.Surname.Length > 20 || user.Email.Length > 35)
            {
                throw new FlowException("Please check input length limit!");
            }
        }

    }
}
