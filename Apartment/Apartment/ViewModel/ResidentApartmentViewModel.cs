using Apartment.Models;
namespace Apartment.ViewModel
{
    public class ResidentApartmentViewModel
    {
        public int Id { get; set; }
        public virtual Resident Resident { get; set; }
        public virtual ApartmentAddress ApartmentAddress { get; set; }
    }
}