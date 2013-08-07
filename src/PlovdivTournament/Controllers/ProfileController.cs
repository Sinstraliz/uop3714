using NHibernate;
using NHibernate.Linq;
using PlovdivTournament.Entities.Entity;
using PlovdivTournament.Web.Library.IdentityAndAccess;
using PlovdivTournament.Web.Models;
using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace PlovdivTournament.Web.Controllers
{
    public class ProfileController : Controller
    {
        public ISession Session { get; set; }

        public SecurityManager SecurityManager { get; set; }

        public ActionResult Index()
        {
            User currentUser = Session.Get<User>(SecurityManager.AuthenticatedUser.Id);
            int photosCount = Session.Query<Photo>().Where(x => x.Owner.Id == currentUser.Id).Count();
            int videosCount = Session.Query<Video>().Where(x => x.Owner.Id == currentUser.Id).Count();
            int commentsCount = Session.Query<Comment>().Where(x => x.Author.Id == currentUser.Id).Count();
            var avatar = currentUser.Avatar;

            if (avatar == null)
                avatar = Session.Load<Avatar>(Avatar.DefaultAvatarId);

            var model = new ProfileViewModel(avatar, currentUser.Email, photosCount, videosCount, commentsCount);

            return View(model);
        }

        public ActionResult Preview(Guid id)
        {
            User currentUser = Session.Get<User>(id);
            int photosCount = Session.Query<Photo>().Where(x => x.Owner.Id == currentUser.Id).Count();
            int videosCount = Session.Query<Video>().Where(x => x.Owner.Id == currentUser.Id).Count();
            int commentsCount = Session.Query<Comment>().Where(x => x.Author.Id == currentUser.Id).Count();
            var avatar = currentUser.Avatar;

            if (avatar == null)
                avatar = Session.Load<Avatar>(Avatar.DefaultAvatarId);

            var model = new ProfileViewModel(avatar, currentUser.Email, photosCount, videosCount, commentsCount);

            return View(model);
        }

        public ActionResult Edit()
        {
            var model = new EditProfileViewModel();

            model.Email = SecurityManager.AuthenticatedUser.Email;

            return View(model);
        }


        [HttpPost]
        public ActionResult Save(EditProfileViewModel model)
        {
            TryValidateModel(model);

            if (!ModelState.IsValid)
                return View("Edit", model);

            User currentUser = Session.Get<User>(SecurityManager.AuthenticatedUser.Id);

            if (!String.IsNullOrEmpty(model.NewPassword))
            {
                if (model.OldPassword == currentUser.Password)
                    currentUser.Password = model.NewPassword;
                else
                {
                    ModelState.AddModelError("invPass", "Invalid password");
                    model.OldPassword = string.Empty;
                    model.NewPassword = string.Empty;
                    model.RepeatPassword = string.Empty;
                    return View("Edit", model);
                }
            }

            currentUser.Email = model.Email;
            currentUser.Phone = model.Phone;
            currentUser.Fax = model.Fax;

            if (model.NewAvatar != null)
            {
                Avatar newAvatar = currentUser.Avatar;
                MemoryStream target = new MemoryStream();
                model.NewAvatar.InputStream.CopyTo(target);
                byte[] data = target.ToArray();
                //Session.Delete(newAvatar);
                newAvatar = new Avatar(Guid.NewGuid(), data, currentUser, DateTime.Now, model.NewAvatar.ContentType);
                currentUser.Avatar = newAvatar;
                Session.Save(newAvatar);
            }

            SecurityManager.Logout();
            SecurityManager.AuthenticateUser(currentUser.Email, currentUser.Password);

            return RedirectToAction("Index");
        }
    }
}