using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlovdivTournament.Web.Manage.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ISession Session { get; set; }

        public ActionResult Index()
        {
            return View();
        }

    }
}
