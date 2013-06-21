using Barcaliente.Domain.Abstract;
using Barcaliente.Domain.Concrete;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Barcaliente.WebUI.Infarstructure.Abstract;
using Barcaliente.WebUI.Infarstructure.Concrete;

namespace Barcaliente.WebUI.Infarstructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel _ninjectKernel;

        public NinjectControllerFactory()
        {
            _ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)_ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            _ninjectKernel.Bind<IMealRepository>().To<EFMealRepository>();
            _ninjectKernel.Bind<IPromotionRepository>().To<EFPromotionRepository>();
            _ninjectKernel.Bind<IUserRepository>().To<EFUserRepository>();
            _ninjectKernel.Bind<IAuthProvider>().To<CustomFormsAuthProvider>();
        }
    }
}