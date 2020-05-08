using ShareITAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareITAPI.Interfaces.FriendsInterface
{
    public interface IFriendsRepository : IBaseRepository<Friends>
    {
        Friends GetFirstInclude(Func<Friends, bool> predicate);

        List<Friends> GetWhereInclude(Func<Friends, bool> predicate);
    }
}
