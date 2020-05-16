using ShareITAPI.Interfaces;
using ShareITAPI.Models;

namespace ShareITAPI.Repositories
{
    public class CommentsRepository : BaseRepository<Comments>, ICommentsRepository
    {
        public CommentsRepository(DB_A57889_shareITContext context) : base(context)
        {

        }
    }
}
