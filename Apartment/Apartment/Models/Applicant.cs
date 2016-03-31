using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apartment.Models
{
  
    public class Applicant
    {
        [Key, ForeignKey("Case")]
        public int Id { get; set; }
        public int TenantInformationId { get; set; }
        public int WorkHistoryId { get; set; }
        public int CreditHistoryId { get; set; }
        public int CriminalHistoryId { get; set; }
        public int SpouseId { get; set; }
        public int OtherOccupantsId { get; set; }
        public int VehiclesId { get; set; }
        public int WhyAppliedId { get; set; }
        public int EmergencyContactId { get; set; }
        public int AuthorizationId { get; set; }
       
        public virtual Case Case { get; set; }

        public virtual TenantInformation TenantInformation { get; set; }
        public virtual WorkHistory WorkHistory { get; set; }
        public virtual CreditHistory CreditHistory { get; set; }
        public virtual CriminalHistory CriminalHistory { get; set; }
        public virtual Spouse Spouse { get; set; }
        public virtual OtherOccupants OtherOccupants { get; set; }
        public virtual Vehicles Vehicles { get; set; }
        public virtual WhyApplied WhyApplied { get; set; }
        public virtual EmergencyContact EmergencyContact { get; set; }
        public virtual Authorization Authorization { get; set; }
    }
}