using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PlovdivTournament.Web.Manage.Models;
using NHibernate;
using NHibernate.Linq;
using PlovdivTournament.Entities.Entity;

namespace PlovdivTournament.Web.Manage.Controllers
{
    public class InfoController : MasterController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Fest()
        {
            MasterViewModel model = new MasterViewModel();

            LoadLanguage(model);

            var content = Session.Query<Content>().FirstOrDefault(x => x.Page == "Fest" && x.Language == model.CurrentLanguage);

            if (content != null)
            {
                var html = content.PageContent;

                html = html.Replace("contenteditable=\"true\"", "contenteditable=\"false\"");

                model.PageContent = html;
            }
            return View(model);
        }

        public ActionResult Program()
        {
            MasterViewModel model = new MasterViewModel();

            LoadLanguage(model);

            var content = Session.Query<Content>().FirstOrDefault(x => x.Page == "Program" && x.Language == model.CurrentLanguage);

            if (content != null)
            {
                var html = content.PageContent;

                html = html.Replace("contenteditable=\"true\"", "contenteditable=\"false\"");

                model.PageContent = html;
            }
            return View(model);
        }

        public ActionResult Referees()
        {
            MasterViewModel model = new MasterViewModel();

            LoadLanguage(model);

            var content = Session.Query<Content>().FirstOrDefault(x => x.Page == "Referees" && x.Language == model.CurrentLanguage);

            if (content != null)
            {
                var html = content.PageContent;

                html = html.Replace("contenteditable=\"true\"", "contenteditable=\"false\"");

                model.PageContent = html;
            }
            return View(model);
        }

        public ActionResult Evaluation()
        {
            MasterViewModel model = new MasterViewModel();

            LoadLanguage(model);

            var content = Session.Query<Content>().FirstOrDefault(x => x.Page == "Evaluation" && x.Language == model.CurrentLanguage);

            if (content != null)
            {
                var html = content.PageContent;

                html = html.Replace("contenteditable=\"true\"", "contenteditable=\"false\"");

                model.PageContent = html;
            }
            return View(model);
        }

        public ActionResult Workshops()
        {
            MasterViewModel model = new MasterViewModel();

            LoadLanguage(model);

            var content = Session.Query<Content>().FirstOrDefault(x => x.Page == "Workshops" && x.Language == model.CurrentLanguage);

            if (content != null)
            {
                var html = content.PageContent;

                html = html.Replace("contenteditable=\"true\"", "contenteditable=\"false\"");

                model.PageContent = html;
            }
            return View(model);
        }

        public ActionResult Prizes()
        {
            MasterViewModel model = new MasterViewModel();

            LoadLanguage(model);

            var content = Session.Query<Content>().FirstOrDefault(x => x.Page == "Prizes" && x.Language == model.CurrentLanguage);

            if (content != null)
            {
                var html = content.PageContent;

                html = html.Replace("contenteditable=\"true\"", "contenteditable=\"false\"");

                model.PageContent = html;
            }
            return View(model);
        }

        public ActionResult Accommodation()
        {
            MasterViewModel model = new MasterViewModel();

            LoadLanguage(model);

            var content = Session.Query<Content>().FirstOrDefault(x => x.Page == "Accommodation" && x.Language == model.CurrentLanguage);

            if (content != null)
            {
                var html = content.PageContent;

                html = html.Replace("contenteditable=\"true\"", "contenteditable=\"false\"");

                model.PageContent = html;
            }
            return View(model);
        }

        public ActionResult Results()
        {
            MasterViewModel model = new MasterViewModel();

            LoadLanguage(model);

            var content = Session.Query<Content>().FirstOrDefault(x => x.Page == "Results" && x.Language == model.CurrentLanguage);

            if (content != null)
            {
                var html = content.PageContent;

                html = html.Replace("contenteditable=\"true\"", "contenteditable=\"false\"");

                model.PageContent = html;
            }
            return View(model);
        }

        public ActionResult Styles()
        {
            MasterViewModel model = new MasterViewModel();

            LoadLanguage(model);

            var content = Session.Query<Content>().FirstOrDefault(x => x.Page == "Styles" && x.Language == model.CurrentLanguage);

            if (content != null)
            {
                var html = content.PageContent;

                html = html.Replace("contenteditable=\"true\"", "contenteditable=\"false\"");

                model.PageContent = html;
            }
            return View(model);
        }

        public ActionResult Categories()
        {
            MasterViewModel model = new MasterViewModel();

            LoadLanguage(model);

            var content = Session.Query<Content>().FirstOrDefault(x => x.Page == "Categories" && x.Language == model.CurrentLanguage);

            if (content != null)
            {
                var html = content.PageContent;

                html = html.Replace("contenteditable=\"true\"", "contenteditable=\"false\"");

                model.PageContent = html;
            }
            return View(model);
        }

        public ActionResult Rules()
        {
            MasterViewModel model = new MasterViewModel();

            LoadLanguage(model);

            var content = Session.Query<Content>().FirstOrDefault(x => x.Page == "Rules" && x.Language == model.CurrentLanguage);

            if (content != null)
            {
                var html = content.PageContent;

                html = html.Replace("contenteditable=\"true\"", "contenteditable=\"false\"");

                model.PageContent = html;
            }
            return View(model);
        }

        public ActionResult Regulations()
        {
            MasterViewModel model = new MasterViewModel();

            LoadLanguage(model);

            var content = Session.Query<Content>().FirstOrDefault(x => x.Page == "Regulations" && x.Language == model.CurrentLanguage);

            if (content != null)
            {
                var html = content.PageContent;

                html = html.Replace("contenteditable=\"true\"", "contenteditable=\"false\"");

                model.PageContent = html;
            }
            return View(model);
        }

        public ActionResult Taxes()
        {
            MasterViewModel model = new MasterViewModel();

            LoadLanguage(model);

            var content = Session.Query<Content>().FirstOrDefault(x => x.Page == "Taxes" && x.Language == model.CurrentLanguage);

            if (content != null)
            {
                var html = content.PageContent;

                html = html.Replace("contenteditable=\"true\"", "contenteditable=\"false\"");

                model.PageContent = html;
            }
            return View(model);
        }

        public ActionResult AboutUs()
        {
            MasterViewModel model = new MasterViewModel();

            LoadLanguage(model);

            var content = Session.Query<Content>().FirstOrDefault(x => x.Page == "AboutUs" && x.Language == model.CurrentLanguage);

            if (content != null)
            {
                var html = content.PageContent;

                html = html.Replace("contenteditable=\"true\"", "contenteditable=\"false\"");

                model.PageContent = html;
            }
            return View(model);
        }
    }
}
