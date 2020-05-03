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

        private readonly DB_A57889_shareITContext _context = new DB_A57889_shareITContext();

        public UsersRepository(DB_A57889_shareITContext context) : base(context)
        {
            
        }

        public List<Users> GetAllInclude()
        {
            return _context.Users
                             .Include(x => x.Comments)
                             .Include(x => x.FriendRequestsFromUser)
                             .Include(x => x.FriendRequestsUser)
                             .Include(x => x.FriendsFriend)
                             .Include(x => x.FriendsUser)
                             .Include(x => x.Likes)
                             .Include(x => x.MessagesFromUser)
                             .Include(x => x.MessagesToUser)
                             .Include(x => x.NotificationsFromUsed)
                             .Include(x => x.NotificationsUser)
                             .Include(x => x.Posts)
                             .ToList();
        }
    }
}
