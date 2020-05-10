using ShareITAPI.ModelsDTO.RequestsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
