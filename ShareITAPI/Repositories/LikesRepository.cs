using ShareITAPI.Interfaces;
using ShareITAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareITAPI.Repositories
{
    public class LikesRepository : BaseRepository<Likes>, ILikesRepository
    {
        public LikesRepository(DB_A57889_shareITContext context) : base(context)
        {

        }
    }
}
