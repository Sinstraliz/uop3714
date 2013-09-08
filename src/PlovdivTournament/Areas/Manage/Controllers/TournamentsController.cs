using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate;
using NHibernate.Linq;
using PlovdivTournament.Entities.Entity;
using PlovdivTournament.Web.Manage.Models;
namespace PlovdivTournament.Web.Manage.Controllers
{
    public class TournamentsController : Controller
    {
        //
        // GET: /Tournaments/
        public ISession Session { get; set; }

        public ActionResult Index()
        {
            var model = new TournamentsModel();
            model.Tournaments = Session.Query<Tournament>().ToList();
            return View(model);
        }

    }
}
