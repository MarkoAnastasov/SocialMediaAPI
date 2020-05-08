using Microsoft.EntityFrameworkCore;
using ShareITAPI.Interfaces;
using ShareITAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareITAPI.Repositories
{
    public class PostsRepository : BaseRepository<Posts>, IPostsRepository
    {
        private readonly DB_A57889_shareITContext _context;

        public PostsRepository(DB_A57889_shareITContext context) : base(context)
        {
            _context = context;
        }

        public Posts GetFirstInclude(Func<Posts, bool> predicate)
        {
            return _context.Posts
                             .Include(x => x.User)
                             .Include(x => x.Likes)
                             .ThenInclude(x => x.User)
                             .Include(x => x.Comments)
                             .ThenInclude(x => x.User)
                             .FirstOrDefault(predicate);
        }

        public List<Posts> GetWhereInclude(Func<Posts,bool> predicate)
        {
            return _context.Posts
                             .Include(x => x.User)
                             .Include(x => x.Likes)
                             .ThenInclude(x => x.User)
                             .Include(x => x.Comments)
                             .ThenInclude(x => x.User)
                             .Where(predicate)
                             .ToList();
        }
    }
}
