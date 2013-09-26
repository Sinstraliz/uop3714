using System.Web.Mvc;
using log4net;

namespace PlovdivTournament.Web.Library.Attributes
{
    public class ExceptionHandlingAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            ILog log = LogManager.GetLogger(filterContext.Controller.GetType().FullName);
            log.Error(filterContext.Exception.Message, filterContext.Exception);

            base.OnException(filterContext);
        }
    }
}