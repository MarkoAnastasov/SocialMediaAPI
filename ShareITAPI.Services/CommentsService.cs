using ShareITAPI.Common.Exceptions;
using ShareITAPI.Converters;
using ShareITAPI.Interfaces;
using ShareITAPI.Models;
using ShareITAPI.ModelsDTO.CommentsDTO;

namespace ShareITAPI.Services
{
    public class CommentsService : ICommentsService
    {
        private readonly ICommentsRepository _commentsRepository;

        public CommentsService(ICommentsRepository commentsRepository)
        {
            _commentsRepository = commentsRepository;
        }

        public AddCommentDto AddComment(AddCommentDto comment)
        {
            var addComment = new Comments();

            if (comment.Comment.Length == 0)
            {
                throw new FlowException("Please insert comment!");
            }
            else if (comment.Comment.Length > 100)
            {
                throw new FlowException("Length must be lower than 100chars!");
            }

            addComment = DTOtoModel.AddCommentDTOtoComment(comment, addComment);
            _commentsRepository.Add(addComment);
            _commentsRepository.SaveEntities();

            return comment;
        }

        public void DeleteComment(int id)
        {
            var comment = _commentsRepository.GetById(id);

            if(comment == null)
            {
                throw new FlowException("Comment not found!");
            }

            _commentsRepository.Remove(comment);
            _commentsRepository.SaveEntities();
        }
    }
}
