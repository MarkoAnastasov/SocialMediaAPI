using ShareITAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareITAPI.Interfaces
{
    public interface IPostsRepository : IBaseRepository<Posts>
    {
        Posts GetFirstInclude(Func<Posts, bool> predicate);

        List<Posts> GetWhereInclude(Func<Posts, bool> predicate);
    }
}
