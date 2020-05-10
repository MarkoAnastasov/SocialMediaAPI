using ShareITAPI.Common.Exceptions;
using ShareITAPI.Controllers;
using ShareITAPI.Converters;
using ShareITAPI.Interfaces.FriendsInterface;
using ShareITAPI.Models;
using ShareITAPI.ModelsDTO.FriendsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareITAPI.Services
{
    public class FriendsService : IFriendsService
    {
        private readonly IFriendsRepository _friendsRepository;

        public FriendsService(IFriendsRepository friendsRepository)
        {
            _friendsRepository = friendsRepository;
        }

        public List<FriendsDto> GetFriendsForUser(int userId)
        {
            var friendsForUser = _friendsRepository.GetWhereInclude(x => x.UserId == userId);

            var friendsForUserDto = new List<FriendsDto>();

            foreach (var friend in friendsForUser)
            {
                var friendDto = ModelToDTO.ConvertFriendToDto(friend);
                friendsForUserDto.Add(friendDto);
            }

            return friendsForUserDto;
        }

        public FriendsDto CheckIfFriend(int userId,int targetId)
        {
            var checkIfFriends = _friendsRepository.GetFirstInclude(x => x.UserId == userId && x.FriendId == targetId);

            if (checkIfFriends == null)
            {
                var friendEmpty = new FriendsDto();
                return friendEmpty;
            }

            return ModelToDTO.ConvertFriendToDto(checkIfFriends);
        }

        public void AcceptFriendRequest(AddFriendDto addFriend)
        {
            var existingFriendship = _friendsRepository.GetFirstWhere(x => x.UserId == addFriend.UserId && x.FriendId == addFriend.FriendId);

            if(existingFriendship != null)
            {
                throw new FlowException("Already friends!");
            }

            var newFriend = new Friends()
            {
                UserId = addFriend.UserId,
                FriendId = addFriend.FriendId
            };

            var newFriendTwo = new Friends()
            {
                UserId = addFriend.FriendId,
                FriendId = addFriend.UserId
            };

            _friendsRepository.Add(newFriend);
            _friendsRepository.Add(newFriendTwo);
            _friendsRepository.SaveEntities();
        }

        public void RemoveFriendship(int userId, int targetId)
        {
            var friendship = _friendsRepository.GetFirstInclude(x => x.UserId == userId && x.FriendId == targetId);

            var friendshipTwo = _friendsRepository.GetFirstInclude(x => x.FriendId == userId && x.UserId == targetId);

            if (friendship == null && friendshipTwo == null)
            {
                throw new FlowException("Friendship not found!");
            }

            _friendsRepository.Remove(friendship);
            _friendsRepository.Remove(friendshipTwo);
            _friendsRepository.SaveEntities();
        }
    }
}
