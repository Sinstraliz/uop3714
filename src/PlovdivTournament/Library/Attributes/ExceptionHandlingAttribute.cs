using System.Web.Mvc;

namespace PlovdivTournament.Web.Library.Attributes
{
    public class ExceptionHandlingAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
        }
    }
}