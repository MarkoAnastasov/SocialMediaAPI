using ShareITAPI.ModelsDTO.LikesDTO;

namespace ShareITAPI.Interfaces
{
    public interface ILikesService
    {
        void AddLike(AddLikeDto like);

        void DeleteLike(int userId, int postId);
    }
}
