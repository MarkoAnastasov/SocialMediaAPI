using ShareITAPI.Models;
using ShareITAPI.ModelsDTO;
using ShareITAPI.ModelsDTO.CommentsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareITAPI.Converters
{
    public static class ModelToDTO
    {
        public static List<UserDto> ConvertUsersToDto(List<Users> users)
        {
            var usersToDto = new List<UserDto>();
            foreach (var user in users)
            {
                var userToDto = new UserDto();
                userToDto.Id = user.Id;
                userToDto.FullName = user.Name + ' ' + user.Surname;
                userToDto.DateOfBirth = user.DateOfBirth;
                userToDto.ProfilePicture = user.ProfilePicture;
                userToDto.Gender = user.Gender;
                userToDto.IsPrivate = user.IsPrivate;
                userToDto.IsOnline = user.IsOnline;
                usersToDto.Add(userToDto);
            }
            return usersToDto;
        }

        public static List<UserPostsDto> ConvertUserPostsToDTO(List<Posts> postsForUser)
        {
            var userPostsDto = new List<UserPostsDto>();

            foreach (var post in postsForUser)
            {
                var userPostDto = new UserPostsDto()
                {
                    Id = post.Id,
                    PhotoUploaded = post.PhotoUploaded,
                    TimeUploaded = post.TimeUploaded,
                    Description = post.Description
                };

                userPostDto.User.Id = post.User.Id;
                userPostDto.User.FullName = post.User.Name + ' ' + post.User.Surname;
                userPostDto.User.DateOfBirth = post.User.DateOfBirth;
                userPostDto.User.ProfilePicture = post.User.ProfilePicture;
                userPostDto.User.Gender = post.User.Gender;
                userPostDto.User.IsPrivate = post.User.IsPrivate;
                userPostDto.User.IsOnline = post.User.IsOnline;

                foreach (var like in post.Likes)
                {
                    var newLikeDto = new LikesDto();
                    newLikeDto.DateCreated = like.DateCreated;
                    newLikeDto.PostId = like.PostId;
                    newLikeDto.User = ConvertSingleUserToDto(like.User);

                    userPostDto.Likes.Add(newLikeDto);
                }

                foreach (var comment in post.Comments)
                {
                    var newCommentDto = new CommentsDto();
                    newCommentDto.DateCreated = comment.DateCreated;
                    newCommentDto.PostId = comment.PostId;
                    newCommentDto.Comment = comment.Comment;
                    newCommentDto.User = ConvertSingleUserToDto(comment.User);
                    newCommentDto.Id = comment.Id;

                    userPostDto.Comments.Add(newCommentDto);
                }

                userPostsDto.Add(userPostDto);
            }

            return userPostsDto;
        }

        public static UserDto ConvertSingleUserToDto(Users user)
        {
            var userToDto = new UserDto();
            userToDto.Id = user.Id;
            userToDto.FullName = user.Name + ' ' + user.Surname;
            userToDto.DateOfBirth = user.DateOfBirth;
            userToDto.ProfilePicture = user.ProfilePicture;
            userToDto.Gender = user.Gender;
            userToDto.IsPrivate = user.IsPrivate;
            userToDto.IsOnline = user.IsOnline;

            return userToDto;
        }

    }
}
