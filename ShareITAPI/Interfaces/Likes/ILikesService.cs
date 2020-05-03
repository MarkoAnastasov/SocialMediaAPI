using ShareITAPI.ModelsDTO.LikesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareITAPI.Interfaces
{
    public interface ILikesService
    {
        void AddLike(AddLikeDto like);

        void DeleteLike(int userId, int postId);
    }
}
