using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ShareITAPI.Interfaces
{
    public interface IBaseRepository<T>
    {
        void Add(T entity);

        List<T> GetAll();

        T GetFirstWhere(Func<T, bool> predicate);

        List<T> GetWhere(Func<T, bool> predicate);

        T GetById(int id);

        void Update(T entity);

        void Remove(T entity);

        void SaveEntities();
    }
}
