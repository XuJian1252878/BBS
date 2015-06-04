using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BBS.WebUI.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel kernel;
        public NinjectControllerFactory()
        {
            kernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
/*            return controllerType == null ? null :
                (IController)kernel.Get(controllerType);*/
            return base.GetControllerInstance(requestContext, controllerType);
        }

        private void AddBindings()
        {

        }
    }
}