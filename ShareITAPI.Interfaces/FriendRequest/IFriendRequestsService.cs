using ShareITAPI.ModelsDTO.RequestsDTO;
using System.Collections.Generic;

namespace ShareITAPI.Interfaces.FriendRequest
{
    public interface IFriendRequestsService
    {
        List<FriendRequestDto> GetRequests(int userId);

        FriendRequestDto UserRequest(int userId, int targetId);

        void SendRequest(SendRequestDto request);

        void SeenRequests(int userId);

        void CancelFriendRequest(int userId, int targetId);
    }
}
