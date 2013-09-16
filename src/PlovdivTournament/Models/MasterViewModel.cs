using PlovdivTournament.Web.Library.IdentityAndAccess;
using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using System.Globalization;

namespace PlovdivTournament.Web.Models
{
    public class MasterViewModel
    {
        public MasterViewModel()
        {
            CurrentLanguage = "Български";
        }

        public string Error { get; set; }

        public bool UserIsAuthenticated { get { return MvcApplication.SecurityManager.AuthenticatedUser != null; } }

        public UserInfo CurrentUser { get { return MvcApplication.SecurityManager.AuthenticatedUser; } }

        public string CurrentUrl { get { return HttpContext.Current.Request.Url.PathAndQuery; } }

        public List<string> Cultures
        {
            get
            {
                var cultures = CultureInfo.GetCultures(CultureTypes.NeutralCultures).ToList();

                var countries = new List<string>();

                foreach (var culture in cultures)
                {
                    countries.Add(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(culture.NativeName));
                }

                return countries;
            }
        }

        public string CurrentLanguage { get; set; }

        public string Page { get; set; }

        public string PageContent { get; set; }

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