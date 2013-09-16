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

        public ActionResult Fest(string language)
        {
            MasterViewModel model = new MasterViewModel();

            if (!string.IsNullOrWhiteSpace(language))
                model.CurrentLanguage = language;
            else if (HttpContext.Request.Cookies.AllKeys.Contains("Language"))
                model.CurrentLanguage = HttpContext.Request.Cookies["Language"].Value;

            var content = Session.Query<Content>().FirstOrDefault(x => x.Page == "Fest" && x.Language == model.CurrentLanguage);

            if (content != null)
            {
                var html = content.PageContent;

                html = html.Replace("contenteditable=\"true\"", "contenteditable=\"false\"");

                model.PageContent = html;
            }
            return View(model);
        }

        public ActionResult Program(string language)
        {
            MasterViewModel model = new MasterViewModel();

            if (!string.IsNullOrWhiteSpace(language))
                model.CurrentLanguage = language;
            else if (HttpContext.Request.Cookies.AllKeys.Contains("Language"))
                model.CurrentLanguage = HttpContext.Request.Cookies["Language"].Value;

            var content = Session.Query<Content>().FirstOrDefault(x => x.Page == "Program" && x.Language == model.CurrentLanguage);

            if (content != null)
            {
                var html = content.PageContent;

                html = html.Replace("contenteditable=\"true\"", "contenteditable=\"false\"");

                model.PageContent = html;
            }
            return View(model);
        }

        public ActionResult Referees(string language)
        {
            MasterViewModel model = new MasterViewModel();

            if (!string.IsNullOrWhiteSpace(language))
                model.CurrentLanguage = language;
            else if (HttpContext.Request.Cookies.AllKeys.Contains("Language"))
                model.CurrentLanguage = HttpContext.Request.Cookies["Language"].Value;

            var content = Session.Query<Content>().FirstOrDefault(x => x.Page == "Referees" && x.Language == model.CurrentLanguage);

            if (content != null)
            {
                var html = content.PageContent;

                html = html.Replace("contenteditable=\"true\"", "contenteditable=\"false\"");

                model.PageContent = html;
            }
            return View(model);
        }

        public ActionResult Evaluation(string language)
        {
            MasterViewModel model = new MasterViewModel();

            if (!string.IsNullOrWhiteSpace(language))
                model.CurrentLanguage = language;
            else if (HttpContext.Request.Cookies.AllKeys.Contains("Language"))
                model.CurrentLanguage = HttpContext.Request.Cookies["Language"].Value;

            var content = Session.Query<Content>().FirstOrDefault(x => x.Page == "Evaluation" && x.Language == model.CurrentLanguage);

            if (content != null)
            {
                var html = content.PageContent;

                html = html.Replace("contenteditable=\"true\"", "contenteditable=\"false\"");

                model.PageContent = html;
            }
            return View(model);
        }

        public ActionResult Workshops(string language)
        {
            MasterViewModel model = new MasterViewModel();

            if (!string.IsNullOrWhiteSpace(language))
                model.CurrentLanguage = language;
            else if (HttpContext.Request.Cookies.AllKeys.Contains("Language"))
                model.CurrentLanguage = HttpContext.Request.Cookies["Language"].Value;

            var content = Session.Query<Content>().FirstOrDefault(x => x.Page == "Workshops" && x.Language == model.CurrentLanguage);

            if (content != null)
            {
                var html = content.PageContent;

                html = html.Replace("contenteditable=\"true\"", "contenteditable=\"false\"");

                model.PageContent = html;
            }
            return View(model);
        }

        public ActionResult Prizes(string language)
        {
            MasterViewModel model = new MasterViewModel();

            if (!string.IsNullOrWhiteSpace(language))
                model.CurrentLanguage = language;
            else if (HttpContext.Request.Cookies.AllKeys.Contains("Language"))
                model.CurrentLanguage = HttpContext.Request.Cookies["Language"].Value;

            var content = Session.Query<Content>().FirstOrDefault(x => x.Page == "Prizes" && x.Language == model.CurrentLanguage);

            if (content != null)
            {
                var html = content.PageContent;

                html = html.Replace("contenteditable=\"true\"", "contenteditable=\"false\"");

                model.PageContent = html;
            }
            return View(model);
        }

        public ActionResult Accommodation(string language)
        {
            MasterViewModel model = new MasterViewModel();

            if (!string.IsNullOrWhiteSpace(language))
                model.CurrentLanguage = language;
            else if (HttpContext.Request.Cookies.AllKeys.Contains("Language"))
                model.CurrentLanguage = HttpContext.Request.Cookies["Language"].Value;

            var content = Session.Query<Content>().FirstOrDefault(x => x.Page == "Accommodation" && x.Language == model.CurrentLanguage);

            if (content != null)
            {
                var html = content.PageContent;

                html = html.Replace("contenteditable=\"true\"", "contenteditable=\"false\"");

                model.PageContent = html;
            }
            return View(model);
        }

        public ActionResult Results(string language)
        {
            MasterViewModel model = new MasterViewModel();

            if (!string.IsNullOrWhiteSpace(language))
                model.CurrentLanguage = language;
            else if (HttpContext.Request.Cookies.AllKeys.Contains("Language"))
                model.CurrentLanguage = HttpContext.Request.Cookies["Language"].Value;

            var content = Session.Query<Content>().FirstOrDefault(x => x.Page == "Results" && x.Language == model.CurrentLanguage);

            if (content != null)
            {
                var html = content.PageContent;

                html = html.Replace("contenteditable=\"true\"", "contenteditable=\"false\"");

                model.PageContent = html;
            }
            return View(model);
        }

        public ActionResult Styles(string language)
        {
            MasterViewModel model = new MasterViewModel();

            if (!string.IsNullOrWhiteSpace(language))
                model.CurrentLanguage = language;
            else if (HttpContext.Request.Cookies.AllKeys.Contains("Language"))
                model.CurrentLanguage = HttpContext.Request.Cookies["Language"].Value;

            var content = Session.Query<Content>().FirstOrDefault(x => x.Page == "Styles" && x.Language == model.CurrentLanguage);

            if (content != null)
            {
                var html = content.PageContent;

                html = html.Replace("contenteditable=\"true\"", "contenteditable=\"false\"");

                model.PageContent = html;
            }
            return View(model);
        }

        public ActionResult Rules(string language)
        {
            MasterViewModel model = new MasterViewModel();

            if (!string.IsNullOrWhiteSpace(language))
                model.CurrentLanguage = language;
            else if (HttpContext.Request.Cookies.AllKeys.Contains("Language"))
                model.CurrentLanguage = HttpContext.Request.Cookies["Language"].Value;

            var content = Session.Query<Content>().FirstOrDefault(x => x.Page == "Rules" && x.Language == model.CurrentLanguage);

            if (content != null)
            {
                var html = content.PageContent;

                html = html.Replace("contenteditable=\"true\"", "contenteditable=\"false\"");

                model.PageContent = html;
            }
            return View(model);
        }

        public ActionResult Regulations(string language)
        {
            MasterViewModel model = new MasterViewModel();

            if (!string.IsNullOrWhiteSpace(language))
                model.CurrentLanguage = language;
            else if (HttpContext.Request.Cookies.AllKeys.Contains("Language"))
                model.CurrentLanguage = HttpContext.Request.Cookies["Language"].Value;

            var content = Session.Query<Content>().FirstOrDefault(x => x.Page == "Regulations" && x.Language == model.CurrentLanguage);

            if (content != null)
            {
                var html = content.PageContent;

                html = html.Replace("contenteditable=\"true\"", "contenteditable=\"false\"");

                model.PageContent = html;
            }
            return View(model);
        }

        public ActionResult Taxes(string language)
        {
            MasterViewModel model = new MasterViewModel();

            if (!string.IsNullOrWhiteSpace(language))
                model.CurrentLanguage = language;
            else if (HttpContext.Request.Cookies.AllKeys.Contains("Language"))
                model.CurrentLanguage = HttpContext.Request.Cookies["Language"].Value;

            var content = Session.Query<Content>().FirstOrDefault(x => x.Page == "Taxes" && x.Language == model.CurrentLanguage);

            if (content != null)
            {
                var html = content.PageContent;

                html = html.Replace("contenteditable=\"true\"", "contenteditable=\"false\"");

                model.PageContent = html;
            }
            return View(model);
        }

        public ActionResult AboutUs(string language)
        {
            MasterViewModel model = new MasterViewModel();

            if (!string.IsNullOrWhiteSpace(language))
                model.CurrentLanguage = language;
            else if (HttpContext.Request.Cookies.AllKeys.Contains("Language"))
                model.CurrentLanguage = HttpContext.Request.Cookies["Language"].Value;

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
