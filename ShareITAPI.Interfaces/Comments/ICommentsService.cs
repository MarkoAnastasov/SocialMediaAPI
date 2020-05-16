using ShareITAPI.ModelsDTO.CommentsDTO;

namespace ShareITAPI.Interfaces
{
    public interface ICommentsService
    {
        AddCommentDto AddComment(AddCommentDto comment);

        void DeleteComment(int id);
    }
}
