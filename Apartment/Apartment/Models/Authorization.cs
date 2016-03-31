using System.ComponentModel.DataAnnotations;

namespace Apartment.Models
{
    public class Authorization
    {
        public int Id { get; set; }
        [Required, DataType(DataType.EmailAddress), Display(Name = "Email:")]
        public string Email { get; set; }
        [DataType(DataType.PhoneNumber), Display(Name ="Phone:")]
        public string Phone { get; set; }
        [Required]
        public bool AcceptTerms { get; set; }
        [Required, Display(Name ="E-Signature")]
        public string ESignature { get; set; }
        [Display(Name = "Spouse Signature:")]
        public string SpouseSignature { get; set; }
        [Display(Name = "Additional Comments:")]
        public string AdditionalComments { get; set; }

    }
}