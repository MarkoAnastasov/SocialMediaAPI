using ShareITAPI.Models;
using ShareITAPI.ModelsDTO.FriendsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareITAPI.Interfaces.FriendsInterface
{
    public interface IFriendsService
    {
        List<FriendsDto> GetFriendsForUser(int userId);

        FriendsDto CheckIfFriend(int userId, int targetId);

        void AcceptFriendRequest(AddFriendDto addFriend);

        void RemoveFriendship(int userId, int targetId);
    }
}
