using ShareITAPI.Common.Exceptions;
using ShareITAPI.Converters;
using ShareITAPI.Interfaces;
using ShareITAPI.Models;
using ShareITAPI.ModelsDTO.LikesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareITAPI.Services
{
    public class LikesService : ILikesService
    {
        private readonly ILikesRepository _likesRepository;

        public LikesService(ILikesRepository likesRepository)
        {
            _likesRepository = likesRepository;
        }

        public void AddLike(AddLikeDto like)
        {
            var likes = _likesRepository.GetAll();

            var addLike = new Likes();

            var existingLike = likes.FirstOrDefault(x => x.UserId == like.UserId && x.PostId == like.PostId);
            if(existingLike != null)
            {
                throw new FlowException("Like already exists!");
            }

            addLike = DTOtoModel.AddLikeDTOtoLike(like, addLike);
            _likesRepository.Add(addLike);
            _likesRepository.SaveEntities();
        }

        public void DeleteLike(int userId, int postId)
        {
            var likes = _likesRepository.GetAll();

            var targetLike = likes.FirstOrDefault(x => x.UserId == userId && x.PostId == postId);
            if(targetLike == null)
            {
                throw new FlowException("Like not found!");
            }

            _likesRepository.Remove(targetLike);
            _likesRepository.SaveEntities();
        }
    }
}
