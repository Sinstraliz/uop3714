using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PlovdivTournament.Entities.Entity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PlovdivTournament.Web.Models
{
    public class RegisterViewModel : MasterViewModel
    {
        public List<Tournament> Tournaments { get; set; }

        public Guid SelectedTournamentId { get; set; }

        public Tournament SelectedTournament { get; set; }

        public Guid SelectedDisciplineId { get; set; }

        public Discipline SelectedDiscipline { get; set; }

        public Guid SelectedCategoryId { get; set; }

        public Category SelectedCategory { get; set; }

        public Guid SelectedAgeGroupId { get; set; }

        public AgeGroup SelectedAgeGroup { get; set; }

        public Club CurrentClub { get; set; }

        public string SelectedClubMembers { get; set; }

        [Required]
        [DisplayName("Име на танца")]
        public string DanceName { get; set; }

        public List<CategoryMember> RegisteredMembers { get; set; }
    }
}