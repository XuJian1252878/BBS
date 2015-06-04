using BBS.Service.BusinessInterfaces.Base;
using BBS.Service.Module;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.Service.BusinessServices.Base
{
    public class BaseService: IBaseService
    {
        private static IKernel kernel = null;

        static BaseService()//相当于静态代码块
        {
            if (kernel == null)
            {
                kernel = new StandardKernel(new ServiceModule());
            }
        }

        public T LoadRepository<T>()
        {
            return kernel.Get<T>();
        }
    }
}
