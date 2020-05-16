using ShareITAPI.Models;
using System.Collections.Generic;

namespace ShareITAPI.Interfaces
{
    public interface IUsersRepository : IBaseRepository<Users>
    {
        List<Users> GetAllInclude();
    }
}
