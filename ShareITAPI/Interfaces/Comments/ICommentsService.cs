using ShareITAPI.ModelsDTO.CommentsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareITAPI.Interfaces
{
    public interface ICommentsService
    {
        AddCommentDto AddComment(AddCommentDto comment);

        void DeleteComment(int id);
    }
}
