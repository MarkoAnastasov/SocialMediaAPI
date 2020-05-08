using ShareITAPI.ModelsDTO.RequestsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareITAPI.Interfaces.FriendRequest
{
    public interface IFriendRequestsService
    {
        List<FriendRequestDto> GetRequests(int userId, List<FriendRequestDto> requestsForUserDto);

        FriendRequestDto UserRequest(int userId, int targetId, FriendRequestDto friendRequestDto);

        void SendRequest(SendRequestDto request);

        void SeenRequests(int userId);

        void CancelFriendRequest(int userId, int targetId);
    }
}
