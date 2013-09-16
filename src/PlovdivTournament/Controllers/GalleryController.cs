using NHibernate;
using NHibernate.Linq;
using PlovdivTournament.Entities.Entity;
using PlovdivTournament.Web.Library.IdentityAndAccess;
using PlovdivTournament.Web.Library.Utility;
using PlovdivTournament.Web.Models;
using System;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace PlovdivTournament.Web.Controllers
{
    public class GalleryController : MasterController
    {
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
            model.AllVideos = allVideos.Skip(page * 12).Take(12).ToList();

            model.MaxPages = (int)Math.Ceiling(allVideos.Count() / 12.0);

            return View(model);
        }

        [HttpGet]
        public ActionResult Photos(string category = "", int page = 1, string orderBy = "dateCreated", string asc = "false", Guid? owner = null)
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
            model.AllPhotos = allPhotos.Skip(page * 12).Take(12).ToList();

            model.MaxPages = (int)Math.Ceiling(allPhotos.Count() / 12.0);

            return View(model);
        }

        public string GetVideo(Guid id, int width, int height)
        {
            var video = Session.Get<Video>(id);
            if (video == null)
            {
                return null;
            }
            else
            {
                var builder = new StringBuilder();

                builder.Append(String.Format("<iframe width={0} height={1} src=\"//www.youtube-nocookie.com/embed/{2}\" frameborder=\"0\" allowfullscreen></iframe>", width, height, video.Url));

                return builder.ToString();
            }
        }

        public void GetVideoCover(Guid id, int? width, int? height, int? maxWidth, int? maxHeight)
        {
            var video = Session.Get<Video>(id);
            if (video == null)
            {
                HttpContext.Response.StatusCode = 404;
            }
            else
            {
                var key = this.BuildChacheKey(id, width, height, maxWidth, maxHeight);
                byte[] data = HttpContext.Cache[key] as byte[];
                if (data == null)
                {
                    data = video.CoverContent;
                    if ((width.HasValue && (maxHeight.HasValue || height.HasValue)) || (height.HasValue && (width.HasValue || maxWidth.HasValue)))
                        data = ImageUtility.SmartResize(video.CoverContent, width, height, maxWidth, maxHeight);

                    HttpContext.Cache[key] = data;
                }
                HttpContext.Response.BinaryWrite(data);
                HttpContext.Response.ContentType = video.CoverContentType;
                HttpContext.Response.StatusCode = 200;
            }
            HttpContext.Response.End();
        }

        public void GetImage(Guid id, int? width, int? height, int? maxWidth, int? maxHeight)
        {
            var photo = Session.Get<Image>(id);
            if (photo == null)
            {
                HttpContext.Response.StatusCode = 404;
            }
            else
            {
                var key = this.BuildChacheKey(id, width, height, maxWidth, maxHeight);
                byte[] data = HttpContext.Cache[key] as byte[];
                if (data == null)
                {
                    data = photo.Content;
                    if ((width.HasValue && (maxHeight.HasValue || height.HasValue)) || (height.HasValue && (width.HasValue || maxWidth.HasValue)))
                        data = ImageUtility.SmartResize(photo.Content, width, height, maxWidth, maxHeight);

                    HttpContext.Cache[key] = data;
                }
                HttpContext.Response.BinaryWrite(data);
                HttpContext.Response.ContentType = photo.ContentType;
                HttpContext.Response.StatusCode = 200;
            }
            HttpContext.Response.End();
        }

        private string BuildChacheKey(Guid id, int? width, int? height, int? maxWidth, int? maxHeight)
        {
            var key = String.Format("{0}{1}{2}{3}{4}",
                                     id,
                                     width.HasValue ? width.Value.ToString() : "null",
                                     height.HasValue ? height.Value.ToString() : "null",
                                     maxWidth.HasValue ? maxWidth.Value.ToString() : "null",
                                     maxHeight.HasValue ? maxHeight.Value.ToString() : "null"
            );
            return key;
        }

        [HttpGet]
        public ActionResult Preview(Guid id, string type)
        {
            var model = new GalleryViewModel();

            if (type == typeof(Photo).FullName)
            {
                model.Photo = Session.Query<Photo>().Where(x => x.Id == id).FirstOrDefault();

                if (model.Photo == null)
                {
                    return Redirect("/");
                }
            }
            else if (type == typeof(Video).FullName)
            {
                model.Video = Session.Query<Video>().Where(x => x.Id == id).FirstOrDefault();

                if (model.Video == null)
                {
                    return Redirect("/");
                }
            }

            return View(model);
        }

        public ActionResult Delete(Guid id, string type)
        {
            if (type == typeof(Photo).FullName)
            {
                var photo = Session.Get<Photo>(id);
                if (photo == null)
                    return Redirect("/");

                if (SecurityManager.AuthenticatedUser == null || (SecurityManager.AuthenticatedUser != null && (!(SecurityManager.AuthenticatedUser.IsAdmin || SecurityManager.AuthenticatedUser.Id == photo.Owner.Id))))
                    return Redirect("/");

                Session.Delete(photo);
            }
            else if (type == typeof(Photo).FullName)
            {
                var video = Session.Get<Video>(id);
                if (video == null)
                    return Redirect("/");

                if (SecurityManager.AuthenticatedUser == null || (SecurityManager.AuthenticatedUser != null && (!(SecurityManager.AuthenticatedUser.IsAdmin || SecurityManager.AuthenticatedUser.Id == video.Owner.Id))))
                    return Redirect("/");

                Session.Delete(video);
            }

            return Redirect("/");
        }

        private bool LoggedUserHasEditAccessFor<T>(T item)
        {
            if (item.As<Photo>() != null)
            {
                var photo = item.As<Photo>();

                return SecurityManager.AuthenticatedUser.IsAdmin || SecurityManager.AuthenticatedUser.Id == photo.Owner.Id;
            }
            else if (item.As<Video>() != null)
            {
                var video = item.As<Video>();

                return SecurityManager.AuthenticatedUser.IsAdmin || SecurityManager.AuthenticatedUser.Id == video.Owner.Id;
            }

            return false;
        }
    }
}