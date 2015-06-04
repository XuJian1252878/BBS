using BBS.Domain.Abstract.Base;
using BBS.Domain.Concrete.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.Domain.Concrete.Base
{
    public class EFTypeRepository<T> : ITypeRepository<T> where T : class
    {
        protected EFDbContext context = new EFDbContext();

        public IQueryable<T> GetAll()
        {
            return context.Set<T>();
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return context.Set<T>().Where<T>(predicate);
        }

        public bool Create(T entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException("EFTypeRepository : Create method entity parameter null");
            }
            context.Set<T>().Add(entity);
            context.SaveChanges();
            return true;
        }

        public bool Delete(T entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException("EFTypeRepository : Delete method entity parameter null");
            }
            context.Set<T>().Remove(entity);
            context.SaveChanges();
            return true;
        }

        public bool Attach(T entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException("EFTypeRepository : Attach method entity parameter null");
            }
            context.Set<T>().Attach(entity);
            context.SaveChanges();
            return true;
        }
    }
}
