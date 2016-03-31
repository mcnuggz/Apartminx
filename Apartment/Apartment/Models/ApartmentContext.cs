using Apartment.ViewModel;
using System.Data.Entity;

namespace Apartment.Models
{
    public class ApartmentContext : DbContext
    {
        public ApartmentContext() : base("DefaultConnection")
        {

        }
        public DbSet<ApartmentAddress> Addresses { get; set; }
        public DbSet<Resident> Residents { get; set; }
        public DbSet<Case> Cases { get; set; }
        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<PetCost> PetCosts { get; set; }

        public DbSet<Section> Sections { get; set; }
        public DbSet<BathCount> BathCount { get; set; }
        public DbSet<RentCost> Costs { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<UnitNumber> Units { get; set; }
        public DbSet<Street> Streets { get; set; }
        public DbSet<PostalCode> ZipCodes { get; set; }
        public DbSet<RoomCount> RoomCounts { get; set; }

        public DbSet<TenantInformation> TenantInformations { get; set; }
        public DbSet<WorkHistory> WorkHistories { get; set; }
        public DbSet<CreditHistory> CreditHistories { get; set; }
        public DbSet<CriminalHistory> CriminalHistories { get; set; }
        public DbSet<Spouse> Spouses { get; set; }
        public DbSet<OtherOccupants> OtherOccupants { get; set; }
        public DbSet<Vehicles> Vehicles { get; set; }
        public DbSet<WhyApplied> WhyApplieds { get; set; }
        public DbSet<EmergencyContact> EmergencyContacts { get; set; }
        public DbSet<Authorization> Authorizations { get; set; }

        public DbSet<ResidentApartmentViewModel> ResidentApartmentViewModels { get; set; }
    }
}