using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.Domain.Abstract.Base
{
    public interface ITypeRepository<T> where T: class
    {
        IQueryable<T> GetAll();
        IEnumerable<T> Find(Func<T, bool> predicate);
        bool Create(T entity);
        bool Delete(T entiry);
        bool Attach(T entity);
    }
}
