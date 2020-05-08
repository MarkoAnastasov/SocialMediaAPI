using Microsoft.EntityFrameworkCore;
using ShareITAPI.Interfaces;
using ShareITAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareITAPI.Repositories
{
    public class UsersRepository : BaseRepository<Users> , IUsersRepository
    {

        private readonly DB_A57889_shareITContext _context;

        public UsersRepository(DB_A57889_shareITContext context) : base(context)
        {
            _context = context;
        }

        public List<Users> GetAllInclude()
        {
            return _context.Users
                             .Include(x => x.FriendsFriend)
                             .Include(x => x.FriendsUser)
                             .ToList();
        }
    }
}
