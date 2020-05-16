using Microsoft.EntityFrameworkCore;
using ShareITAPI.Interfaces.FriendsInterface;
using ShareITAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShareITAPI.Repositories
{
    public class FriendsRepository : BaseRepository<Friends>, IFriendsRepository
    {
        private readonly DB_A57889_shareITContext _context;

        public FriendsRepository(DB_A57889_shareITContext context) : base(context)
        {
            _context = context;
        }

        public Friends GetFirstInclude(Func<Friends, bool> predicate)
        {
            return _context.Friends
                             .Include(x => x.User)
                             .Include(x => x.Friend)
                             .FirstOrDefault(predicate);
        }

        public List<Friends> GetWhereInclude(Func<Friends,bool> predicate)
        {
            return _context.Friends
                             .Include(x => x.User)
                             .Include(x => x.Friend)
                             .Where(predicate)
                             .ToList();
        }
    }
}
