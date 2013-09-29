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

            LoadLanguage(model);

            model.Tournaments = Session.Query<Tournament>().ToList();

            return View(model);
        }

        public ActionResult Activate(Guid id)
        {
            var tournament = Session.Query<Tournament>().FirstOrDefault(x => x.Id == id);

            tournament.IsActive = true;

            Session.SaveOrUpdate(tournament);

            var model = new TournamentsViewModel();

            LoadLanguage(model);

            model.Tournaments = Session.Query<Tournament>().ToList();

            return View("Index", model);
        }

        public ActionResult Deactivate(Guid id)
        {
            var tournament = Session.Query<Tournament>().FirstOrDefault(x => x.Id == id);

            tournament.IsActive = false;

            Session.SaveOrUpdate(tournament);

            var model = new TournamentsViewModel();

            LoadLanguage(model);

            model.Tournaments = Session.Query<Tournament>().ToList();

            return View("Index", model);
        }

        [HttpPost]
        public ActionResult SaveTournament(TournamentsViewModel model)
        {
            #region Класически танц

            var clasicalDanceSoloMaleAgeGroups = new List<AgeGroup>();
            clasicalDanceSoloMaleAgeGroups.Add(new AgeGroup("до 8г.", 0, 8, 0));
            clasicalDanceSoloMaleAgeGroups.Add(new AgeGroup("9-11г.", 9, 11, 7));
            clasicalDanceSoloMaleAgeGroups.Add(new AgeGroup("12-15г.", 12, 15, 10));
            clasicalDanceSoloMaleAgeGroups.Add(new AgeGroup("над 16г.", 16, int.MaxValue, 14));

            var clasicalDanceSoloFemaleAgeGroups = new List<AgeGroup>();
            clasicalDanceSoloFemaleAgeGroups.Add(new AgeGroup("до 8г.", 0, 8, 0));
            clasicalDanceSoloFemaleAgeGroups.Add(new AgeGroup("9-11г.", 9, 11, 7));
            clasicalDanceSoloFemaleAgeGroups.Add(new AgeGroup("12-15г.", 12, 15, 10));
            clasicalDanceSoloFemaleAgeGroups.Add(new AgeGroup("над 16г.", 16, int.MaxValue, 14));

            var clasicalDanceDuoAgeGroups = new List<AgeGroup>();
            clasicalDanceDuoAgeGroups.Add(new AgeGroup("до 8г.", 0, 8, 0));
            clasicalDanceDuoAgeGroups.Add(new AgeGroup("9-11г.", 9, 11, 7));
            clasicalDanceDuoAgeGroups.Add(new AgeGroup("12-15г.", 12, 15, 10));
            clasicalDanceDuoAgeGroups.Add(new AgeGroup("над 16г.", 16, int.MaxValue, 14));

            var clasicalDanceGroupAgeGroups = new List<AgeGroup>();
            clasicalDanceGroupAgeGroups.Add(new AgeGroup("до 8г.", 0, 8, 0));
            clasicalDanceGroupAgeGroups.Add(new AgeGroup("9-11г.", 9, 11, 7));
            clasicalDanceGroupAgeGroups.Add(new AgeGroup("12-15г.", 12, 15, 10));
            clasicalDanceGroupAgeGroups.Add(new AgeGroup("над 16г.", 16, int.MaxValue, 14));

            var clasicalDanceFormationAgeGroups = new List<AgeGroup>();
            clasicalDanceFormationAgeGroups.Add(new AgeGroup("до 8г.", 0, 8, 0));
            clasicalDanceFormationAgeGroups.Add(new AgeGroup("9-11г.", 9, 11, 7));
            clasicalDanceFormationAgeGroups.Add(new AgeGroup("12-15г.", 12, 15, 10));
            clasicalDanceFormationAgeGroups.Add(new AgeGroup("над 16г.", 16, int.MaxValue, 14));

            var clasicalDanceCategories = new List<Category>();
            clasicalDanceCategories.Add(new Category("Соло жени", clasicalDanceSoloFemaleAgeGroups, 1, 1));
            clasicalDanceCategories.Add(new Category("Соло мъже", clasicalDanceSoloMaleAgeGroups, 1, 1));
            clasicalDanceCategories.Add(new Category("Дует", clasicalDanceDuoAgeGroups, 2, 2));
            clasicalDanceCategories.Add(new Category("Група", clasicalDanceGroupAgeGroups, 3, 7));
            clasicalDanceCategories.Add(new Category("Формация", clasicalDanceFormationAgeGroups, 8, 24));

            #endregion

            #region Модерен танц

            var modernDanceSoloMaleAgeGroups = new List<AgeGroup>();
            modernDanceSoloMaleAgeGroups.Add(new AgeGroup("до 8г.", 0, 8, 0));
            modernDanceSoloMaleAgeGroups.Add(new AgeGroup("9-11г.", 9, 11, 7));
            modernDanceSoloMaleAgeGroups.Add(new AgeGroup("12-15г.", 12, 15, 10));
            modernDanceSoloMaleAgeGroups.Add(new AgeGroup("над 16г.", 16, int.MaxValue, 14));

            var modernDanceSoloFemaleAgeGroups = new List<AgeGroup>();
            modernDanceSoloFemaleAgeGroups.Add(new AgeGroup("до 8г.", 0, 8, 0));
            modernDanceSoloFemaleAgeGroups.Add(new AgeGroup("9-11г.", 9, 11, 7));
            modernDanceSoloFemaleAgeGroups.Add(new AgeGroup("12-15г.", 12, 15, 10));
            modernDanceSoloFemaleAgeGroups.Add(new AgeGroup("над 16г.", 16, int.MaxValue, 14));

            var modernDanceDuoAgeGroups = new List<AgeGroup>();
            modernDanceDuoAgeGroups.Add(new AgeGroup("до 8г.", 0, 8, 0));
            modernDanceDuoAgeGroups.Add(new AgeGroup("9-11г.", 9, 11, 7));
            modernDanceDuoAgeGroups.Add(new AgeGroup("12-15г.", 12, 15, 10));
            modernDanceDuoAgeGroups.Add(new AgeGroup("над 16г.", 16, int.MaxValue, 14));

            var modernDanceGroupAgeGroups = new List<AgeGroup>();
            modernDanceGroupAgeGroups.Add(new AgeGroup("до 8г.", 0, 8, 0));
            modernDanceGroupAgeGroups.Add(new AgeGroup("9-11г.", 9, 11, 7));
            modernDanceGroupAgeGroups.Add(new AgeGroup("12-15г.", 12, 15, 10));
            modernDanceGroupAgeGroups.Add(new AgeGroup("над 16г.", 16, int.MaxValue, 14));

            var modernDanceFormationAgeGroups = new List<AgeGroup>();
            modernDanceFormationAgeGroups.Add(new AgeGroup("до 8г.", 0, 8, 0));
            modernDanceFormationAgeGroups.Add(new AgeGroup("9-11г.", 9, 11, 7));
            modernDanceFormationAgeGroups.Add(new AgeGroup("12-15г.", 12, 15, 10));
            modernDanceFormationAgeGroups.Add(new AgeGroup("над 16г.", 16, int.MaxValue, 14));

            var modernDanceCategories = new List<Category>();
            modernDanceCategories.Add(new Category("Соло жени", modernDanceSoloFemaleAgeGroups, 1, 1));
            modernDanceCategories.Add(new Category("Соло мъже", modernDanceSoloMaleAgeGroups, 1, 1));
            modernDanceCategories.Add(new Category("Дует", modernDanceDuoAgeGroups, 2, 2));
            modernDanceCategories.Add(new Category("Група", modernDanceGroupAgeGroups, 3, 7));
            modernDanceCategories.Add(new Category("Формация", modernDanceFormationAgeGroups, 8, 24));

            #endregion

            #region Джаз танц

            var jazDanceSoloMaleAgeGroups = new List<AgeGroup>();
            jazDanceSoloMaleAgeGroups.Add(new AgeGroup("до 8г.", 0, 8, 0));
            jazDanceSoloMaleAgeGroups.Add(new AgeGroup("9-11г.", 9, 11, 7));
            jazDanceSoloMaleAgeGroups.Add(new AgeGroup("12-15г.", 12, 15, 10));
            jazDanceSoloMaleAgeGroups.Add(new AgeGroup("над 16г.", 16, int.MaxValue, 14));

            var jazDanceSoloFemaleAgeGroups = new List<AgeGroup>();
            jazDanceSoloFemaleAgeGroups.Add(new AgeGroup("до 8г.", 0, 8, 0));
            jazDanceSoloFemaleAgeGroups.Add(new AgeGroup("9-11г.", 9, 11, 7));
            jazDanceSoloFemaleAgeGroups.Add(new AgeGroup("12-15г.", 12, 15, 10));
            jazDanceSoloFemaleAgeGroups.Add(new AgeGroup("над 16г.", 16, int.MaxValue, 14));

            var jazDanceDuoAgeGroups = new List<AgeGroup>();
            jazDanceDuoAgeGroups.Add(new AgeGroup("до 8г.", 0, 8, 0));
            jazDanceDuoAgeGroups.Add(new AgeGroup("9-11г.", 9, 11, 7));
            jazDanceDuoAgeGroups.Add(new AgeGroup("12-15г.", 12, 15, 10));
            jazDanceDuoAgeGroups.Add(new AgeGroup("над 16г.", 16, int.MaxValue, 14));

            var jazDanceGroupAgeGroups = new List<AgeGroup>();
            jazDanceGroupAgeGroups.Add(new AgeGroup("до 8г.", 0, 8, 0));
            jazDanceGroupAgeGroups.Add(new AgeGroup("9-11г.", 9, 11, 7));
            jazDanceGroupAgeGroups.Add(new AgeGroup("12-15г.", 12, 15, 10));
            jazDanceGroupAgeGroups.Add(new AgeGroup("над 16г.", 16, int.MaxValue, 14));

            var jazDanceFormationAgeGroups = new List<AgeGroup>();
            jazDanceFormationAgeGroups.Add(new AgeGroup("до 8г.", 0, 8, 0));
            jazDanceFormationAgeGroups.Add(new AgeGroup("9-11г.", 9, 11, 7));
            jazDanceFormationAgeGroups.Add(new AgeGroup("12-15г.", 12, 15, 10));
            jazDanceFormationAgeGroups.Add(new AgeGroup("над 16г.", 16, int.MaxValue, 14));

            var jazDanceCategories = new List<Category>();
            jazDanceCategories.Add(new Category("Соло жени", jazDanceSoloFemaleAgeGroups, 1, 1));
            jazDanceCategories.Add(new Category("Соло мъже", jazDanceSoloMaleAgeGroups, 1, 1));
            jazDanceCategories.Add(new Category("Дует", jazDanceDuoAgeGroups, 2, 2));
            jazDanceCategories.Add(new Category("Група", jazDanceGroupAgeGroups, 3, 7));
            jazDanceCategories.Add(new Category("Формация", jazDanceFormationAgeGroups, 8, 24));

            #endregion

            #region Характерен танц

            var typicalDanceSoloFemaleAgeGroups = new List<AgeGroup>();
            typicalDanceSoloFemaleAgeGroups.Add(new AgeGroup("до 8г.", 0, 8, 0));
            typicalDanceSoloFemaleAgeGroups.Add(new AgeGroup("9-11г.", 9, 11, 7));
            typicalDanceSoloFemaleAgeGroups.Add(new AgeGroup("12-15г.", 12, 15, 10));
            typicalDanceSoloFemaleAgeGroups.Add(new AgeGroup("над 16г.", 16, int.MaxValue, 14));

            var typicalDanceSoloMaleAgeGroups = new List<AgeGroup>();
            typicalDanceSoloMaleAgeGroups.Add(new AgeGroup("до 8г.", 0, 8, 0));
            typicalDanceSoloMaleAgeGroups.Add(new AgeGroup("9-11г.", 9, 11, 7));
            typicalDanceSoloMaleAgeGroups.Add(new AgeGroup("12-15г.", 12, 15, 10));
            typicalDanceSoloMaleAgeGroups.Add(new AgeGroup("над 16г.", 16, int.MaxValue, 14));

            var typicalDanceDuoAgeGroups = new List<AgeGroup>();
            typicalDanceDuoAgeGroups.Add(new AgeGroup("до 8г.", 0, 8, 0));
            typicalDanceDuoAgeGroups.Add(new AgeGroup("9-11г.", 9, 11, 7));
            typicalDanceDuoAgeGroups.Add(new AgeGroup("12-15г.", 12, 15, 10));
            typicalDanceDuoAgeGroups.Add(new AgeGroup("над 16г.", 16, int.MaxValue, 14));

            var typicalDanceGroupAgeGroups = new List<AgeGroup>();
            typicalDanceGroupAgeGroups.Add(new AgeGroup("до 8г.", 0, 8, 0));
            typicalDanceGroupAgeGroups.Add(new AgeGroup("9-11г.", 9, 11, 7));
            typicalDanceGroupAgeGroups.Add(new AgeGroup("12-15г.", 12, 15, 10));
            typicalDanceGroupAgeGroups.Add(new AgeGroup("над 16г.", 16, int.MaxValue, 14));

            var typicalDanceFormationAgeGroups = new List<AgeGroup>();
            typicalDanceFormationAgeGroups.Add(new AgeGroup("до 8г.", 0, 8, 0));
            typicalDanceFormationAgeGroups.Add(new AgeGroup("9-11г.", 9, 11, 7));
            typicalDanceFormationAgeGroups.Add(new AgeGroup("12-15г.", 12, 15, 10));
            typicalDanceFormationAgeGroups.Add(new AgeGroup("над 16г.", 16, int.MaxValue, 14));

            var typicalDanceCategories = new List<Category>();
            typicalDanceCategories.Add(new Category("Соло жени", typicalDanceSoloFemaleAgeGroups, 1, 1));
            typicalDanceCategories.Add(new Category("Соло мъже", typicalDanceSoloMaleAgeGroups, 1, 1));
            typicalDanceCategories.Add(new Category("Дует", typicalDanceDuoAgeGroups, 2, 2));
            typicalDanceCategories.Add(new Category("Група", typicalDanceGroupAgeGroups, 3, 7));
            typicalDanceCategories.Add(new Category("Формация", typicalDanceFormationAgeGroups, 8, 24));

            #endregion

            #region Танцово шоу

            var danceShowSoloFemaleAgeGroups = new List<AgeGroup>();
            danceShowSoloFemaleAgeGroups.Add(new AgeGroup("до 8г.", 0, 8, 0));
            danceShowSoloFemaleAgeGroups.Add(new AgeGroup("9-11г.", 9, 11, 7));
            danceShowSoloFemaleAgeGroups.Add(new AgeGroup("12-15г.", 12, 15, 10));
            danceShowSoloFemaleAgeGroups.Add(new AgeGroup("над 16г.", 16, int.MaxValue, 14));

            var danceShowSoloMaleAgeGroups = new List<AgeGroup>();
            danceShowSoloMaleAgeGroups.Add(new AgeGroup("до 8г.", 0, 8, 0));
            danceShowSoloMaleAgeGroups.Add(new AgeGroup("9-11г.", 9, 11, 7));
            danceShowSoloMaleAgeGroups.Add(new AgeGroup("12-15г.", 12, 15, 10));
            danceShowSoloMaleAgeGroups.Add(new AgeGroup("над 16г.", 16, int.MaxValue, 14));

            var danceShowDuoAgeGroups = new List<AgeGroup>();
            danceShowDuoAgeGroups.Add(new AgeGroup("до 8г.", 0, 8, 0));
            danceShowDuoAgeGroups.Add(new AgeGroup("9-11г.", 9, 11, 7));
            danceShowDuoAgeGroups.Add(new AgeGroup("12-15г.", 12, 15, 10));
            danceShowDuoAgeGroups.Add(new AgeGroup("над 16г.", 16, int.MaxValue, 14));

            var danceShowGroupAgeGroups = new List<AgeGroup>();
            danceShowGroupAgeGroups.Add(new AgeGroup("до 8г.", 0, 8, 0));
            danceShowGroupAgeGroups.Add(new AgeGroup("9-11г.", 9, 11, 7));
            danceShowGroupAgeGroups.Add(new AgeGroup("12-15г.", 12, 15, 10));
            danceShowGroupAgeGroups.Add(new AgeGroup("над 16г.", 16, int.MaxValue, 14));

            var danceShowFormationAgeGroups = new List<AgeGroup>();
            danceShowFormationAgeGroups.Add(new AgeGroup("до 8г.", 0, 8, 0));
            danceShowFormationAgeGroups.Add(new AgeGroup("9-11г.", 9, 11, 7));
            danceShowFormationAgeGroups.Add(new AgeGroup("12-15г.", 12, 15, 10));
            danceShowFormationAgeGroups.Add(new AgeGroup("над 16г.", 16, int.MaxValue, 14));

            var danceShowCategories = new List<Category>();
            danceShowCategories.Add(new Category("Соло жени", danceShowSoloFemaleAgeGroups, 1, 1));
            danceShowCategories.Add(new Category("Соло мъже", danceShowSoloMaleAgeGroups, 1, 1));
            danceShowCategories.Add(new Category("Дует", danceShowDuoAgeGroups, 2, 2));
            danceShowCategories.Add(new Category("Група", danceShowGroupAgeGroups, 3, 7));
            danceShowCategories.Add(new Category("Формация", danceShowFormationAgeGroups, 8, 24));

            #endregion

            #region Танцово шоу Б

            var danceShowBSoloFemaleAgeGroups = new List<AgeGroup>();
            danceShowBSoloFemaleAgeGroups.Add(new AgeGroup("до 8г.", 0, 8, 0));
            danceShowBSoloFemaleAgeGroups.Add(new AgeGroup("9-11г.", 9, 11, 7));
            danceShowBSoloFemaleAgeGroups.Add(new AgeGroup("12-15г.", 12, 15, 10));
            danceShowBSoloFemaleAgeGroups.Add(new AgeGroup("над 16г.", 16, int.MaxValue, 14));

            var danceShowBSoloMaleAgeGroups = new List<AgeGroup>();
            danceShowBSoloMaleAgeGroups.Add(new AgeGroup("до 8г.", 0, 8, 0));
            danceShowBSoloMaleAgeGroups.Add(new AgeGroup("9-11г.", 9, 11, 7));
            danceShowBSoloMaleAgeGroups.Add(new AgeGroup("12-15г.", 12, 15, 10));
            danceShowBSoloMaleAgeGroups.Add(new AgeGroup("над 16г.", 16, int.MaxValue, 14));

            var danceShowBDuoAgeGroups = new List<AgeGroup>();
            danceShowBDuoAgeGroups.Add(new AgeGroup("до 8г.", 0, 8, 0));
            danceShowBDuoAgeGroups.Add(new AgeGroup("9-11г.", 9, 11, 7));
            danceShowBDuoAgeGroups.Add(new AgeGroup("12-15г.", 12, 15, 10));
            danceShowBDuoAgeGroups.Add(new AgeGroup("над 16г.", 16, int.MaxValue, 14));

            var danceShowBGroupAgeGroups = new List<AgeGroup>();
            danceShowBGroupAgeGroups.Add(new AgeGroup("до 8г.", 0, 8, 0));
            danceShowBGroupAgeGroups.Add(new AgeGroup("9-11г.", 9, 11, 7));
            danceShowBGroupAgeGroups.Add(new AgeGroup("12-15г.", 12, 15, 10));
            danceShowBGroupAgeGroups.Add(new AgeGroup("над 16г.", 16, int.MaxValue, 14));

            var danceShowBFormationAgeGroups = new List<AgeGroup>();
            danceShowBFormationAgeGroups.Add(new AgeGroup("до 8г.", 0, 8, 0));
            danceShowBFormationAgeGroups.Add(new AgeGroup("9-11г.", 9, 11, 7));
            danceShowBFormationAgeGroups.Add(new AgeGroup("12-15г.", 12, 15, 10));
            danceShowBFormationAgeGroups.Add(new AgeGroup("над 16г.", 16, int.MaxValue, 14));

            var danceShowBCategories = new List<Category>();
            danceShowBCategories.Add(new Category("Соло жени", danceShowBSoloFemaleAgeGroups, 1, 1));
            danceShowBCategories.Add(new Category("Соло мъже", danceShowBSoloMaleAgeGroups, 1, 1));
            danceShowBCategories.Add(new Category("Соло", danceShowBSoloFemaleAgeGroups, 1, 1));
            danceShowBCategories.Add(new Category("Дует", danceShowBDuoAgeGroups, 2, 2));
            danceShowBCategories.Add(new Category("Група", danceShowBGroupAgeGroups, 3, 7));
            danceShowBCategories.Add(new Category("Формация", danceShowBFormationAgeGroups, 8, 24));

            #endregion

            #region Етно шоу

            var ethnoShowSoloFemaleAgeGroups = new List<AgeGroup>();
            ethnoShowSoloFemaleAgeGroups.Add(new AgeGroup("до 8г.", 0, 8, 0));
            ethnoShowSoloFemaleAgeGroups.Add(new AgeGroup("9-11г.", 9, 11, 7));
            ethnoShowSoloFemaleAgeGroups.Add(new AgeGroup("12-15г.", 12, 15, 10));
            ethnoShowSoloFemaleAgeGroups.Add(new AgeGroup("над 16г.", 16, int.MaxValue, 14));

            var ethnoShowSoloMaleAgeGroups = new List<AgeGroup>();
            ethnoShowSoloMaleAgeGroups.Add(new AgeGroup("до 8г.", 0, 8, 0));
            ethnoShowSoloMaleAgeGroups.Add(new AgeGroup("9-11г.", 9, 11, 7));
            ethnoShowSoloMaleAgeGroups.Add(new AgeGroup("12-15г.", 12, 15, 10));
            ethnoShowSoloMaleAgeGroups.Add(new AgeGroup("над 16г.", 16, int.MaxValue, 14));

            var ethnoShowDuoAgeGroups = new List<AgeGroup>();
            ethnoShowDuoAgeGroups.Add(new AgeGroup("до 8г.", 0, 8, 0));
            ethnoShowDuoAgeGroups.Add(new AgeGroup("9-11г.", 9, 11, 7));
            ethnoShowDuoAgeGroups.Add(new AgeGroup("12-15г.", 12, 15, 10));
            ethnoShowDuoAgeGroups.Add(new AgeGroup("над 16г.", 16, int.MaxValue, 14));

            var ethnoShowGroupAgeGroups = new List<AgeGroup>();
            ethnoShowGroupAgeGroups.Add(new AgeGroup("до 8г.", 0, 8, 0));
            ethnoShowGroupAgeGroups.Add(new AgeGroup("9-11г.", 9, 11, 7));
            ethnoShowGroupAgeGroups.Add(new AgeGroup("12-15г.", 12, 15, 10));
            ethnoShowGroupAgeGroups.Add(new AgeGroup("над 16г.", 16, int.MaxValue, 14));

            var ethnoShowFormationAgeGroups = new List<AgeGroup>();
            ethnoShowFormationAgeGroups.Add(new AgeGroup("до 8г.", 0, 8, 0));
            ethnoShowFormationAgeGroups.Add(new AgeGroup("9-11г.", 9, 11, 7));
            ethnoShowFormationAgeGroups.Add(new AgeGroup("12-15г.", 12, 15, 10));
            ethnoShowFormationAgeGroups.Add(new AgeGroup("над 16г.", 16, int.MaxValue, 14));

            var ethnoShowCategories = new List<Category>();
            ethnoShowCategories.Add(new Category("Соло жени", ethnoShowSoloFemaleAgeGroups, 1, 1));
            ethnoShowCategories.Add(new Category("Соло мъже", ethnoShowSoloMaleAgeGroups, 1, 1));
            ethnoShowCategories.Add(new Category("Дует", ethnoShowDuoAgeGroups, 2, 2));
            ethnoShowCategories.Add(new Category("Група", ethnoShowGroupAgeGroups, 3, 7));
            ethnoShowCategories.Add(new Category("Формация", ethnoShowFormationAgeGroups, 8, 24));

            #endregion

            #region Латино шоу

            var latinShowSoloFemaleAgeGroups = new List<AgeGroup>();
            latinShowSoloFemaleAgeGroups.Add(new AgeGroup("до 8г.", 0, 8, 0));
            latinShowSoloFemaleAgeGroups.Add(new AgeGroup("9-11г.", 9, 11, 7));
            latinShowSoloFemaleAgeGroups.Add(new AgeGroup("12-15г.", 12, 15, 10));
            latinShowSoloFemaleAgeGroups.Add(new AgeGroup("над 16г.", 16, int.MaxValue, 14));

            var latinShowSoloMaleAgeGroups = new List<AgeGroup>();
            latinShowSoloMaleAgeGroups.Add(new AgeGroup("до 8г.", 0, 8, 0));
            latinShowSoloMaleAgeGroups.Add(new AgeGroup("9-11г.", 9, 11, 7));
            latinShowSoloMaleAgeGroups.Add(new AgeGroup("12-15г.", 12, 15, 10));
            latinShowSoloMaleAgeGroups.Add(new AgeGroup("над 16г.", 16, int.MaxValue, 14));

            var latinShowDuoAgeGroups = new List<AgeGroup>();
            latinShowDuoAgeGroups.Add(new AgeGroup("до 8г.", 0, 8, 0));
            latinShowDuoAgeGroups.Add(new AgeGroup("9-11г.", 9, 11, 7));
            latinShowDuoAgeGroups.Add(new AgeGroup("12-15г.", 12, 15, 10));
            latinShowDuoAgeGroups.Add(new AgeGroup("над 16г.", 16, int.MaxValue, 14));

            var latinShowGroupAgeGroups = new List<AgeGroup>();
            latinShowGroupAgeGroups.Add(new AgeGroup("до 8г.", 0, 8, 0));
            latinShowGroupAgeGroups.Add(new AgeGroup("9-11г.", 9, 11, 7));
            latinShowGroupAgeGroups.Add(new AgeGroup("12-15г.", 12, 15, 10));
            latinShowGroupAgeGroups.Add(new AgeGroup("над 16г.", 16, int.MaxValue, 14));

            var latinShowFormationAgeGroups = new List<AgeGroup>();
            latinShowFormationAgeGroups.Add(new AgeGroup("до 8г.", 0, 8, 0));
            latinShowFormationAgeGroups.Add(new AgeGroup("9-11г.", 9, 11, 7));
            latinShowFormationAgeGroups.Add(new AgeGroup("12-15г.", 12, 15, 10));
            latinShowFormationAgeGroups.Add(new AgeGroup("над 16г.", 16, int.MaxValue, 14));

            var latinShowCategories = new List<Category>();
            latinShowCategories.Add(new Category("Соло жени", latinShowSoloFemaleAgeGroups, 1, 1));
            latinShowCategories.Add(new Category("Соло мъже", latinShowSoloMaleAgeGroups, 1, 1));
            latinShowCategories.Add(new Category("Дует", latinShowDuoAgeGroups, 2, 2));
            latinShowCategories.Add(new Category("Група", latinShowGroupAgeGroups, 3, 7));
            latinShowCategories.Add(new Category("Формация", latinShowFormationAgeGroups, 8, 24));

            #endregion

            #region Acrogym

            var acrogymSoloFemaleAgeGroups = new List<AgeGroup>();
            acrogymSoloFemaleAgeGroups.Add(new AgeGroup("до 8г.", 0, 8, 0));
            acrogymSoloFemaleAgeGroups.Add(new AgeGroup("9-11г.", 9, 11, 7));
            acrogymSoloFemaleAgeGroups.Add(new AgeGroup("12-15г.", 12, 15, 10));
            acrogymSoloFemaleAgeGroups.Add(new AgeGroup("над 16г.", 16, int.MaxValue, 14));

            var acrogymSoloMaleAgeGroups = new List<AgeGroup>();
            acrogymSoloMaleAgeGroups.Add(new AgeGroup("до 8г.", 0, 8, 0));
            acrogymSoloMaleAgeGroups.Add(new AgeGroup("9-11г.", 9, 11, 7));
            acrogymSoloMaleAgeGroups.Add(new AgeGroup("12-15г.", 12, 15, 10));
            acrogymSoloMaleAgeGroups.Add(new AgeGroup("над 16г.", 16, int.MaxValue, 14));

            var acrogymDuoAgeGroups = new List<AgeGroup>();
            acrogymDuoAgeGroups.Add(new AgeGroup("до 8г.", 0, 8, 0));
            acrogymDuoAgeGroups.Add(new AgeGroup("9-11г.", 9, 11, 7));
            acrogymDuoAgeGroups.Add(new AgeGroup("12-15г.", 12, 15, 10));
            acrogymDuoAgeGroups.Add(new AgeGroup("над 16г.", 16, int.MaxValue, 14));

            var acrogymGroupAgeGroups = new List<AgeGroup>();
            acrogymGroupAgeGroups.Add(new AgeGroup("до 8г.", 0, 8, 0));
            acrogymGroupAgeGroups.Add(new AgeGroup("9-11г.", 9, 11, 7));
            acrogymGroupAgeGroups.Add(new AgeGroup("12-15г.", 12, 15, 10));
            acrogymGroupAgeGroups.Add(new AgeGroup("над 16г.", 16, int.MaxValue, 14));

            var acrogymFormationAgeGroups = new List<AgeGroup>();
            acrogymFormationAgeGroups.Add(new AgeGroup("до 8г.", 0, 8, 0));
            acrogymFormationAgeGroups.Add(new AgeGroup("9-11г.", 9, 11, 7));
            acrogymFormationAgeGroups.Add(new AgeGroup("12-15г.", 12, 15, 10));
            acrogymFormationAgeGroups.Add(new AgeGroup("над 16г.", 16, int.MaxValue, 14));

            var AcrogymCategories = new List<Category>();
            AcrogymCategories.Add(new Category("Соло жени", acrogymSoloFemaleAgeGroups, 1, 1));
            AcrogymCategories.Add(new Category("Соло мъже", acrogymSoloMaleAgeGroups, 1, 1));
            AcrogymCategories.Add(new Category("Дует", acrogymDuoAgeGroups, 2, 2));
            AcrogymCategories.Add(new Category("Група", acrogymGroupAgeGroups, 3, 7));
            AcrogymCategories.Add(new Category("Формация", acrogymFormationAgeGroups, 8, 24));

            #endregion

            #region Hip Hop

            var hipHopOneVSOneAgeGroups = new List<AgeGroup>();
            hipHopOneVSOneAgeGroups.Add(new AgeGroup("default", 0, int.MaxValue, 0));

            var hipHopGroupAgeGroups = new List<AgeGroup>();
            hipHopGroupAgeGroups.Add(new AgeGroup("default", 0, int.MaxValue, 0));

            var hipHopCategories = new List<Category>();
            hipHopCategories.Add(new Category("1 vs 1", hipHopOneVSOneAgeGroups, 1, 1));
            hipHopCategories.Add(new Category("Отбор", hipHopGroupAgeGroups, 3, 60));

            #endregion

            #region Break Battle

            var breakBattleOneVSOneAgeGroups = new List<AgeGroup>();
            breakBattleOneVSOneAgeGroups.Add(new AgeGroup("default", 0, int.MaxValue, 0));

            var breakBattleGroupAgeGroups = new List<AgeGroup>();
            breakBattleGroupAgeGroups.Add(new AgeGroup("default", 0, int.MaxValue, 0));

            var breakBattleCategories = new List<Category>();
            breakBattleCategories.Add(new Category("1 vs 1", breakBattleOneVSOneAgeGroups, 1, 1));
            breakBattleCategories.Add(new Category("Отбор", breakBattleGroupAgeGroups, 3, 60));

            #endregion

            #region Free Open Dance

            var freeOpenDanceSoloFemaleAgeGroups = new List<AgeGroup>();
            freeOpenDanceSoloFemaleAgeGroups.Add(new AgeGroup("до 12г.", 0, 12, 0));
            freeOpenDanceSoloFemaleAgeGroups.Add(new AgeGroup("над 12г.", 12, int.MaxValue, 12));

            var freeOpenDanceSoloMaleAgeGroups = new List<AgeGroup>();
            freeOpenDanceSoloMaleAgeGroups.Add(new AgeGroup("до 12г.", 0, 12, 0));
            freeOpenDanceSoloMaleAgeGroups.Add(new AgeGroup("над 12г.", 12, int.MaxValue, 12));

            var freeOpenDanceDuoAgeGroups = new List<AgeGroup>();
            freeOpenDanceDuoAgeGroups.Add(new AgeGroup("до 12г.", 0, 12, 0));
            freeOpenDanceDuoAgeGroups.Add(new AgeGroup("над 12г.", 12, int.MaxValue, 12));

            var freeOpenDanceGroupAgeGroups = new List<AgeGroup>();
            freeOpenDanceGroupAgeGroups.Add(new AgeGroup("до 12г.", 0, 12, 0));
            freeOpenDanceGroupAgeGroups.Add(new AgeGroup("над 12г.", 12, int.MaxValue, 12));

            var freeOpenDanceCategories = new List<Category>();
            freeOpenDanceCategories.Add(new Category("Соло жени", freeOpenDanceSoloFemaleAgeGroups, 1, 1));
            freeOpenDanceCategories.Add(new Category("Соло мъже", freeOpenDanceSoloMaleAgeGroups, 1, 1));
            freeOpenDanceCategories.Add(new Category("Дует", freeOpenDanceDuoAgeGroups, 2, 2));
            freeOpenDanceCategories.Add(new Category("Група", freeOpenDanceGroupAgeGroups, 3, 60));

            #endregion

            #region Party Time Seniors

            var partyTimeSeniorsSoloFemaleAgeGroups = new List<AgeGroup>();
            partyTimeSeniorsSoloFemaleAgeGroups.Add(new AgeGroup("default", 0, int.MaxValue, 0));

            var partyTimeSeniorsSoloMaleAgeGroups = new List<AgeGroup>();
            partyTimeSeniorsSoloMaleAgeGroups.Add(new AgeGroup("default", 0, int.MaxValue, 0));

            var partyTimeSeniorsDuoAgeGroups = new List<AgeGroup>();
            partyTimeSeniorsDuoAgeGroups.Add(new AgeGroup("default", 0, int.MaxValue, 0));

            var partyTimeSeniorsGroupAgeGroups = new List<AgeGroup>();
            partyTimeSeniorsGroupAgeGroups.Add(new AgeGroup("default", 0, int.MaxValue, 0));

            var partyTimeSeniorsFormationAgeGroups = new List<AgeGroup>();
            partyTimeSeniorsFormationAgeGroups.Add(new AgeGroup("default", 0, int.MaxValue, 0));

            var partyTimeSeniorsCategories = new List<Category>();
            partyTimeSeniorsCategories.Add(new Category("Соло жени", partyTimeSeniorsSoloFemaleAgeGroups, 1, 1));
            partyTimeSeniorsCategories.Add(new Category("Соло мъже", partyTimeSeniorsSoloMaleAgeGroups, 1, 1));
            partyTimeSeniorsCategories.Add(new Category("Дует", partyTimeSeniorsDuoAgeGroups, 2, 2));
            partyTimeSeniorsCategories.Add(new Category("Група", partyTimeSeniorsGroupAgeGroups, 3, 7));
            partyTimeSeniorsCategories.Add(new Category("Формация", partyTimeSeniorsFormationAgeGroups, 3, 60));

            #endregion

            #region Small Production

            var smallProductionSoloAgeGroups = new List<AgeGroup>();
            smallProductionSoloAgeGroups.Add(new AgeGroup("default", 0, int.MaxValue, 0));

            var smallProductionCategories = new List<Category>();
            smallProductionCategories.Add(new Category("default", smallProductionSoloAgeGroups, 3, 12));

            #endregion

            #region Big Production

            var bigProductionAgeGroups = new List<AgeGroup>();
            bigProductionAgeGroups.Add(new AgeGroup("default", 0, int.MaxValue, 0));

            var bigProductionCategories = new List<Category>();
            bigProductionCategories.Add(new Category("default", bigProductionAgeGroups, 25, 60));

            #endregion

            model.NewTournament.Disciplines = new List<Discipline>();

            model.NewTournament.Disciplines.Add(new Discipline("Класически танц", model.NewTournament, clasicalDanceCategories));
            model.NewTournament.Disciplines.Add(new Discipline("Модерен танц", model.NewTournament, modernDanceCategories));
            model.NewTournament.Disciplines.Add(new Discipline("Джаз танц", model.NewTournament, jazDanceCategories));
            model.NewTournament.Disciplines.Add(new Discipline("Танцово шоу", model.NewTournament, danceShowCategories));
            model.NewTournament.Disciplines.Add(new Discipline("Танцово шоу Б", model.NewTournament, danceShowBCategories));
            model.NewTournament.Disciplines.Add(new Discipline("Acrogym", model.NewTournament, AcrogymCategories));
            model.NewTournament.Disciplines.Add(new Discipline("Характерен танц", model.NewTournament, typicalDanceCategories));
            model.NewTournament.Disciplines.Add(new Discipline("Етно шоу", model.NewTournament, ethnoShowCategories));
            model.NewTournament.Disciplines.Add(new Discipline("Латино шоу", model.NewTournament, latinShowCategories));
            model.NewTournament.Disciplines.Add(new Discipline("Hip Hop Battle", model.NewTournament, hipHopCategories));
            model.NewTournament.Disciplines.Add(new Discipline("Break Battle", model.NewTournament, breakBattleCategories));
            model.NewTournament.Disciplines.Add(new Discipline("Free Open Dance", model.NewTournament, freeOpenDanceCategories));
            model.NewTournament.Disciplines.Add(new Discipline("Party Time Seniors", model.NewTournament, partyTimeSeniorsCategories));
            model.NewTournament.Disciplines.Add(new Discipline("Мини Продукция", model.NewTournament, smallProductionCategories));
            model.NewTournament.Disciplines.Add(new Discipline("Продукция", model.NewTournament, bigProductionCategories));

            Session.Save(model.NewTournament);

            return RedirectToAction("Index");
        }
    }
}