using ShareITAPI.Models;
using System;
using System.Collections.Generic;

namespace ShareITAPI.Interfaces
{
    public interface IPostsRepository : IBaseRepository<Posts>
    {
        Posts GetFirstInclude(Func<Posts, bool> predicate);

        List<Posts> GetWhereInclude(Func<Posts, bool> predicate);
    }
}
