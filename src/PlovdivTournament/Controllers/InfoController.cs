using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PlovdivTournament.Web.Models;

namespace PlovdivTournament.Web.Controllers
{
    public class InfoController : Controller
    {
        //
        // GET: /Info/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Fest()
        {
            return View(new HtmlContentModel("Fest result"));
        }

        public ActionResult Program()
        {
            return View(new HtmlContentModel("Program result"));
        }

        public ActionResult Referees()
        {
            return View(new HtmlContentModel("Referess Result"));
        }

        public ActionResult Evaluation()
        {
            return View(new HtmlContentModel("Evaluation Result"));
        }

        public ActionResult Taxes()
        {
            return View(new HtmlContentModel("Taxes result"));
        }
    }
}
