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
        private readonly DB_A57889_shareITContext _context = new DB_A57889_shareITContext();

        public PostsRepository(DB_A57889_shareITContext context) : base(context)
        {

        }

        public List<Posts> GetAllInclude()
        {
            return _context.Posts
                             .Include(x => x.User)
                             .Include(x => x.Likes)
                             .ThenInclude(x => x.User)
                             .Include(x => x.Comments)
                             .ThenInclude(x => x.User)
                             .ToList();
        }
    }
}
