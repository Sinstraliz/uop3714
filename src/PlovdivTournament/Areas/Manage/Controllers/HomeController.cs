﻿using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PlovdivTournament.Web.Manage.Models;
using PlovdivTournament.Entities.Entity;

namespace PlovdivTournament.Web.Manage.Controllers
{
    public class HomeController : MasterController
    {
        [HttpGet]
        public ActionResult Index()
        {
            MasterViewModel model = new MasterViewModel();

            LoadLanguage(model);

            var content = Session.Query<Content>().FirstOrDefault(x => x.Page == "Home" && x.Language == model.CurrentLanguage);

            if (content != null)
                model.PageContent = content.PageContent;

            return View(model);
        }
    }
}
