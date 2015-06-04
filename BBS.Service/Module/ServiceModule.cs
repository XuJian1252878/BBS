using BBS.Domain.Abstract;
using BBS.Domain.Concrete;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.Service.Module
{
    internal class ServiceModule: NinjectModule
    {
        public override void Load()
        {
            //导入数据绑定。
            Bind<IUserRepository>().To<EFUserRepository>();
        }
    }
}
