using System.ComponentModel.DataAnnotations;

namespace Apartment.Models
{
    public class CriminalHistory
    {
        public int Id { get; set; }
        [Display(Name ="Were you ever evicted from a previous address?")]
        public bool Evicted { get; set; }
        [Display(Name = "Did you move out early before giving notice?")]
        public bool EarlyMoveOut { get; set; }
        [Display(Name = "Have you ever filed for backruptcy?")]
        public bool Bankrupt { get; set; }
        [Display(Name = "Were you ever sued for not being able to pay rent?")]
        public bool SuedForRent { get; set; }
        [Display(Name = "Were you ever sued for property damage?")]
        public bool SuedForDamage { get; set; }
        [Display(Name ="Are you a registered sex offender?")]
        public bool RegisteredSexOffender { get; set; }
        [Display(Name = "Have you ever been arrested for domestic violence?")]
        public bool ArrestedForViolence { get; set; }
        [Display(Name = "Have you ever been arrested for commiting a felony?")]
        public bool ArrestedForFelony { get; set; }
        [Display(Name = "If yes, enter information below")]
        public string ArrestInformation { get; set; }

    }
}