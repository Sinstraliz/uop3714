using Foolproof;
using PlovdivTournament.Entities.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PlovdivTournament.Web.Manage.Models
{
    public class GalleryViewModel : MasterViewModel
    {
        public int Page { get; set; }

        public int MaxPages { get; set; }

        public Photo SelectedPhoto { get; set; }

        public Video SelectedVideo { get; set; }

        public List<Photo> AllPhotos { get; set; }

        public List<Video> AllVideos { get; set; }

        public bool IsPhoto { get; set; }

        [RequiredIf("IsPhoto", Operator.EqualTo, true, ErrorMessage = "Photo is required")]
        public HttpPostedFileBase Photo { get; set; }

        [RequiredIf("Photo", Operator.NotEqualTo, null, ErrorMessage = "Title is required")]
        public string PhotoTitle { get; set; }

        public string PhotoDescription { get; set; }

        [RequiredIf("Photo", Operator.NotEqualTo, null, ErrorMessage = "Category is required")]
        public string PhotoCategory { get; set; }

        [RequiredIf("IsPhoto", Operator.EqualTo, false, ErrorMessage = "Video is required")]
        public string VideoUrl { get; set; }

        [RequiredIf("Video", Operator.NotEqualTo, null, ErrorMessage = "Title is required")]
        public string VideoTitle { get; set; }

        public string VideoDescription { get; set; }

        [RequiredIf("Video", Operator.NotEqualTo, null, ErrorMessage = "Category is required")]
        public string VideoCategory { get; set; }

        [RequiredIf("Video", Operator.NotEqualTo, null, ErrorMessage = "Cover is required")]
        public HttpPostedFileBase VideoCover { get; set; }
    }
}