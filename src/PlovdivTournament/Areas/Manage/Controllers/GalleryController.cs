using PlovdivTournament.Entities.Entity;
using PlovdivTournament.Web.Manage.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using NHibernate;
using NHibernate.Linq;
using PlovdivTournament.Web.Manage.Library.Utility;

namespace PlovdivTournament.Web.Manage.Controllers
{
    public class GalleryController : MasterController
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult UploadPhoto()
        {
            var model = new GalleryViewModel();

            LoadLanguage(model);

            model.IsPhoto = true;

            return View(model);
        }

        [HttpPost]
        public ActionResult UploadPhoto(GalleryViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (!model.Photo.ContentType.ToLower().Contains("image"))
                {
                    ModelState.AddModelError("Invalid_image _type", "Invalid image type");
                    return RedirectToAction("");
                }

                MemoryStream target = new MemoryStream();
                model.Photo.InputStream.CopyTo(target);
                byte[] data = target.ToArray();
                var owner = Session.Load<User>(SecurityManager.AuthenticatedUser.Id);
                Session.Save(new Photo(Guid.NewGuid(), data, model.PhotoTitle, model.PhotoDescription, owner, DateTime.Now, model.Photo.ContentType, model.PhotoCategory));
            }

            return RedirectToAction("UploadPhoto");
        }

        [HttpGet]
        public ActionResult UploadVideo()
        {
            var model = new GalleryViewModel();

            LoadLanguage(model);

            model.IsPhoto = false;

            return View(model);
        }

        [HttpPost]
        public ActionResult UploadVideo(GalleryViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (!model.VideoCover.ContentType.ToLower().Contains("image"))
                {
                    ModelState.AddModelError("Invalid_image _type", "Invalid image type");
                    return RedirectToAction("");
                }

                MemoryStream target = new MemoryStream();
                model.VideoCover.InputStream.CopyTo(target);
                byte[] data = target.ToArray();
                var owner = Session.Load<User>(SecurityManager.AuthenticatedUser.Id);
                Session.Save(new Video(Guid.NewGuid(), model.VideoUrl, model.VideoTitle, model.VideoDescription, owner, DateTime.Now, model.PhotoCategory, data, model.VideoCover.ContentType));
            }

            return RedirectToAction("UploadVideo");
        }
    }
}
