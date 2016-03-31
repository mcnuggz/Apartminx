using System.ComponentModel.DataAnnotations;

namespace Apartment.Models
{
    public class Case
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Name:")]
        public string Name { get; set; }
        [Display(Name="Email:")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name ="Application Filled:")]
        public bool ApplicationFilled { get; set; }
        [Display(Name ="Background Checked:")]
        public bool BackgroundStatus { get; set; }
        [Display(Name ="Credit Checked:")]
        public bool CreditReportStatus { get; set; }
        [Display(Name = "Lease Signed:")]
        public bool LeaseSigned { get; set; }
        [Display(Name="Lease:")]
        public string LeasePath { get; set; }
        [Display(Name = "Status:")]
        public AppStatus Status { get; set; }

        public int ApplicantId { get; set; }
        public virtual Applicant Applicant { get; set; }
        
        public enum AppStatus
        {
            [Display(Name ="Waiting for Application")]
            WaitingForApplication,
            [Display(Name = "Pending Approval")]
            PendingApproval,
            [Display(Name = "Waiting for Deposit")]
            WaitingForDeposit,
            [Display(Name = "Deposit Received")]
            DepositReceived,
            [Display(Name = "Lease Signed")]
            LeaseSigned,
            [Display(Name ="Moved In")]
            MovedIn
        }
    }
}