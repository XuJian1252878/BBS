using BBS.Service.BusinessInterfaces;
using BBS.Service.BusinessServices;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BBS.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver()
        {
            kernel = new StandardKernel();
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            //进行接口与其实现的绑定操作。
            kernel.Bind<IAccountService>().To<AccountService>();
            kernel.Bind<IBoardService>().To<BoardService>();
            kernel.Bind<IPostService>().To<PostService>();
            kernel.Bind<IReplyService>().To<ReplyService>();
        }
    }
}