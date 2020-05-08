using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ShareITAPI.Common.Exceptions;
using ShareITAPI.Converters;
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

        public List<FriendRequestDto> GetRequests(int userId,List<FriendRequestDto> requestsForUserDto)
        {
            var requestsForUser = _friendRequestsRepository.GetWhereInclude(x => x.UserId == userId).OrderByDescending(x => x.Id).ToList();

            foreach (var request in requestsForUser)
            {
                var friendRequestDto = new FriendRequestDto();
                requestsForUserDto.Add(ModelToDTO.ConvertRequestToDto(request, friendRequestDto));
            }

            return requestsForUserDto;
        }

        public FriendRequestDto UserRequest(int userId, int targetId, FriendRequestDto friendRequestDto)
        {
            var requestForUser = _friendRequestsRepository.GetFirstInclude(x => x.UserId == targetId && x.FromUserId == userId || (x.UserId == userId && x.FromUserId == targetId));

            if(requestForUser == null)
            {
                var friendRequestEmpty = new FriendRequestDto();
                return friendRequestEmpty;
            }

            return ModelToDTO.ConvertRequestToDto(requestForUser, friendRequestDto);
        }

        public void SendRequest(SendRequestDto request)
        {
            var existingRequest = _friendRequestsRepository.GetFirstWhere(x => x.FromUserId == request.FromUserId && x.UserId == request.ToUserId);

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

        public void SeenRequests(int userId)
        {
            var requestsForUser = _friendRequestsRepository.GetWhereInclude(x => x.UserId == userId);

            foreach (var request in requestsForUser)
            {
                request.Seen = true;
                _friendRequestsRepository.Update(request);
            }

            _friendRequestsRepository.SaveEntities();
        }

        public void CancelFriendRequest(int userId, int targetId)
        {
            var requestForUser = _friendRequestsRepository.GetFirstInclude(x => x.UserId == targetId && x.FromUserId == userId || (x.UserId == userId && x.FromUserId == targetId));

            if (requestForUser == null)
            {
                throw new FlowException("Request not found!");
            }

            _friendRequestsRepository.Remove(requestForUser);
            _friendRequestsRepository.SaveEntities();
        }
    }
}
