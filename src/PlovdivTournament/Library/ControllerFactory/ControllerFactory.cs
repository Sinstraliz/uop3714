using System;
using System.Web.Mvc;

namespace PlovdivTournament.Web.Library.ControllerFactory
{
    public class ControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
                return base.GetControllerInstance(requestContext, controllerType);
            else
                return MvcApplication.Container.Resolve(controllerType, requestContext) as IController;
        }
        public override void ReleaseController(IController controller)
        {
            base.ReleaseController(controller);
        }

    }
}