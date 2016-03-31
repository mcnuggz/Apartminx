using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Apartment.Models
{
    public class EmailForm
    {
        [Required, Display(Name = "From:")]
        public string FromName { get; set; }
        [Required, Display(Name ="Your Email:"), EmailAddress]
        public string FromEmail { get; set; }
        [Required, Display(Name ="Subject:")]
        public string Subject { get; set; }
        [Required, Display(Name ="Message:")]
        public string Message { get; set; }
    }
}