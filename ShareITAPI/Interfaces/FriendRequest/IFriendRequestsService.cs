using ShareITAPI.ModelsDTO.RequestsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareITAPI.Interfaces.FriendRequest
{
    public interface IFriendRequestsService
    {
        void SendRequest(SendRequestDto request);
    }
}
