using PlovdivTournament.Web.Library.IdentityAndAccess;
using System;
using System.Linq;
using System.Web;

namespace PlovdivTournament.Web.Models
{
    public class MasterViewModel
    {
        public bool UserIsAuthenticated { get { return MvcApplication.SecurityManager.AuthenticatedUser != null; } }

        public UserInfo CurrentUser { get { return MvcApplication.SecurityManager.AuthenticatedUser; } }

        public string CurrentUrl { get { return HttpContext.Current.Request.Url.PathAndQuery; } }

        public string ReplaceOrAddToUrl(string currentUrl, string key, string value)
        {
            if (currentUrl.IndexOf(key + "=") != -1)
            {
                var curKvP = currentUrl.Substring(currentUrl.IndexOf(key + "="));
                int lastAnd = curKvP.IndexOf("&");
                if (lastAnd != -1)
                {
                    curKvP = curKvP.Substring(0, lastAnd).Trim('&');
                }
                return currentUrl.Replace(curKvP, String.Format("{0}={1}", key, value));

            }
            else
            {
                if (currentUrl.Contains('?'))
                    return String.Format("{0}&{1}={2}", currentUrl, key, value);
                else
                    return String.Format("{0}?&{1}={2}", currentUrl, key, value);
            }
        }
        public string ReplaceOrAddToUrl(string key, string value)
        {
            return ReplaceOrAddToUrl(CurrentUrl, key, value);
        }
    }
}