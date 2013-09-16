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
    public class TournamentsController : MasterController
    {
        public ISession Session { get; set; }

        [HttpGet]
        public ActionResult Index()
        {
            var model = new TournamentsViewModel();

            model.Tournaments = Session.Query<Tournament>().ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult SaveTournament(TournamentsViewModel model)
        {
            var discipline = new Discipline("Латино", model.NewTournament);
            discipline.Categories = new List<Category>();

            Session.Save(discipline);

            var category = new Category("Малка Група", discipline);

            var ageGroup = new AgeGroup("До 8г.", 1, 8);

            Session.Save(ageGroup);

            category.AgeGroup = ageGroup;

            category.MinNumberOfParticipants = 3;
            category.MaxNumberOfParticipants = 7;

            discipline.Categories.Add(category);

            Session.SaveOrUpdate(discipline);
            Session.Save(category);

            model.NewTournament.AgeGroups = new List<AgeGroup>();
            model.NewTournament.AgeGroups.Add(ageGroup);

            model.NewTournament.Disciplines = new List<Discipline>();
            model.NewTournament.Disciplines.Add(discipline);

            Session.Save(model.NewTournament);

            return RedirectToAction("Index");
        }
    }
}
