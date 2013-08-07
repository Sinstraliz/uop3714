using PlovdivTournament.Entities.Entity;

namespace PlovdivTournament.Web.Models
{
    public class ProfileViewModel : MasterViewModel
    {
        public ProfileViewModel(Image avatar, string email, int photosCount, int videosCount, int commentsCount)
        {
            Avatar = avatar;
            Email = email;
            PhotosCount = photosCount;
            VideosCount = videosCount;
            CommentsCount = commentsCount;
        }

        public Image Avatar { get; set; }

        public string Email { get; set; }

        public int PhotosCount { get; set; }

        public int VideosCount { get; set; }

        public int CommentsCount { get; set; }
    }
}