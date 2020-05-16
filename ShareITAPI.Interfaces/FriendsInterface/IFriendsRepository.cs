using ShareITAPI.Models;
using System;
using System.Collections.Generic;

namespace ShareITAPI.Interfaces.FriendsInterface
{
    public interface IFriendsRepository : IBaseRepository<Friends>
    {
        Friends GetFirstInclude(Func<Friends, bool> predicate);

        List<Friends> GetWhereInclude(Func<Friends, bool> predicate);
    }
}
