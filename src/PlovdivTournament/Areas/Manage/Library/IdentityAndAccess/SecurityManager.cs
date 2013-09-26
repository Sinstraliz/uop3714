using NHibernate;
using NHibernate.Linq;
using PlovdivTournament.Entities.Entity;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Web;

namespace PlovdivTournament.Web.Library.IdentityAndAccess
{
    public sealed class SecurityManager
    {
        private ISession Session { get; set; }

        private static ConcurrentDictionary<String, UserInfo> authenticatedUsers = new ConcurrentDictionary<String, UserInfo>();

        public UserInfo AuthenticatedUser
        {
            get
            {
                try
                {
                    if (authenticatedUsers.ContainsKey(HttpContext.Current.Session.SessionID))
                        return authenticatedUsers[HttpContext.Current.Session.SessionID];
                    else
                        return null;
                }
                catch
                {
                    return null;
                }
            }
        }

        public SecurityManager(ISession session)
        {
            Session = session;
        }

        public bool AuthenticateUser(String email, String password)
        {
            User user = Session.Query<User>().Where(x => x.Email == email && x.Password == password).SingleOrDefault();

            if (user != null)
            {
                UserInfo userInfo = new UserInfo(user.Id, user.Email, user.IsAdmin);

                if (authenticatedUsers.ContainsKey(HttpContext.Current.Session.SessionID))
                    authenticatedUsers[HttpContext.Current.Session.SessionID] = userInfo;
                else
                    authenticatedUsers.TryAdd(HttpContext.Current.Session.SessionID, userInfo);

                HttpContext.Current.Session[typeof(SecurityManager).Name] = this;

                return true;
            }
            else
            {
                UserInfo uInfo;
                authenticatedUsers.TryRemove(HttpContext.Current.Session.SessionID, out uInfo);

                return false;
            }
        }

        public void Logout()
        {
            UserInfo uInfo;
            authenticatedUsers.TryRemove(HttpContext.Current.Session.SessionID, out  uInfo);
        }
    }
}