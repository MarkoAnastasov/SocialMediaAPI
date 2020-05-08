using ShareITAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareITAPI.Interfaces.FriendRequest
{
    public interface IFriendRequestsRepository : IBaseRepository<FriendRequests>
    {
        FriendRequests GetFirstInclude(Func<FriendRequests, bool> predicate);

        List<FriendRequests> GetWhereInclude(Func<FriendRequests, bool> predicate);
    }
}
