using NHibernate;
using NHibernate.Linq;
using PlovdivTournament.Entities.Entity;
using PlovdivTournament.Web.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace PlovdivTournament.Web.Controllers
{
    public class GalleryController : Controller
    {
        public ISession Session { get; set; }

        public ActionResult Videos(string category = "", int page = 1, string orderBy = "dateCreated", string asc = "false", Guid? owner = null)
        {
            page = page - 1;
            GalleryViewModel model = new GalleryViewModel();
            IQueryable<Video> allVideos = null;
            model.Page = page + 1;

            if (String.IsNullOrEmpty(category))
            {
                allVideos = Session.Query<Video>();
            }
            else
            {
                allVideos = Session.Query<Video>().Where(x => x.Category == category);
            }
            if (owner != null)
                allVideos = allVideos.Where(x => x.Owner.Id == owner.Value);
            if (orderBy == "dateCreated")
            {
                if (asc == "false")
                    allVideos = allVideos.OrderByDescending(x => x.DateCreated);
                else
                    allVideos = allVideos.OrderBy(x => x.DateCreated);
            }
            else
            {
                if (asc == "false")
                    allVideos = allVideos.OrderByDescending(x => x.Likes.Count);
                else
                    allVideos = allVideos.OrderBy(x => x.Likes.Count);
            }
            model.AllVideos = allVideos.Skip(page * 12).Take(12).ToList();

            model.MaxPages = (int)Math.Ceiling(allVideos.Count() / 12.0);

            return View(model);
        }

        [HttpGet]
        public ActionResult Pictures(string category = "", int page = 1, string orderBy = "dateCreated", string asc = "false", Guid? owner = null)
        {
            page = page - 1;
            GalleryViewModel model = new GalleryViewModel();
            IQueryable<Photo> allPhotos = null;
            model.Page = page + 1;

            if (String.IsNullOrEmpty(category))
            {
                allPhotos = Session.Query<Photo>();
            }
            else
            {
                allPhotos = Session.Query<Photo>().Where(x => x.Category == category);
            }
            if (owner != null)
                allPhotos = allPhotos.Where(x => x.Owner.Id == owner.Value);
            if (orderBy == "dateCreated")
            {
                if (asc == "false")
                    allPhotos = allPhotos.OrderByDescending(x => x.DateCreated);
                else
                    allPhotos = allPhotos.OrderBy(x => x.DateCreated);
            }
            else
            {
                if (asc == "false")
                    allPhotos = allPhotos.OrderByDescending(x => x.Likes.Count);
                else
                    allPhotos = allPhotos.OrderBy(x => x.Likes.Count);
            }
            model.AllPhotos = allPhotos.Skip(page * 12).Take(12).ToList();

            model.MaxPages = (int)Math.Ceiling(allPhotos.Count() / 12.0);

            return View(model);
        }
    }
}