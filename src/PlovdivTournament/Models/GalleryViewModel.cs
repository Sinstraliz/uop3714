using PlovdivTournament.Entities.Entity;
using System.Collections.Generic;

namespace PlovdivTournament.Web.Models
{
    public class GalleryViewModel : MasterViewModel
    {
        public GalleryViewModel()
        {

        }

        public int Page { get; set; }

        public int MaxPages { get; set; }

        public List<Photo> AllPhotos { get; set; }

        public List<Video> AllVideos { get; set; }
    }
}