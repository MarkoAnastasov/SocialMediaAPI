using ShareITAPI.Interfaces;
using ShareITAPI.Models;

namespace ShareITAPI.Repositories
{
    public class LikesRepository : BaseRepository<Likes>, ILikesRepository
    {
        public LikesRepository(DB_A57889_shareITContext context) : base(context)
        {

        }
    }
}
