using ShareITAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareITAPI.Interfaces
{
    public interface IPostsRepository : IBaseRepository<Posts>
    {
        List<Posts> GetAllInclude();
    }
}
