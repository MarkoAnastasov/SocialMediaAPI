using ShareITAPI.Common.Exceptions;
using ShareITAPI.Interfaces.FriendRequest;
using ShareITAPI.Models;
using ShareITAPI.ModelsDTO.RequestsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareITAPI.Services
{
    public class FriendRequestsService : IFriendRequestsService
    {
        private readonly IFriendRequestsRepository _friendRequestsRepository;

        public FriendRequestsService(IFriendRequestsRepository friendRequestsRepository)
        {
            _friendRequestsRepository = friendRequestsRepository;
        }

        public void SendRequest(SendRequestDto request)
        {
            var requests = _friendRequestsRepository.GetAll();

            var existingRequest = requests.FirstOrDefault(x => x.FromUserId == request.FromUserId && x.UserId == request.ToUserId);

            if(existingRequest != null)
            {
                throw new FlowException("Request already exists!");
            }

            var newRequest = new FriendRequests()
            {
                UserId = request.ToUserId,
                FromUserId = request.FromUserId,
                Seen = false
            };

            _friendRequestsRepository.Add(newRequest);
            _friendRequestsRepository.SaveEntities();
        }
    }
}
