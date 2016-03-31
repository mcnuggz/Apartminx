using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apartment.Models
{
    public class ResidentStatus
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public int ResidentId { get; set; }
        public virtual Resident Resident { get; set; }
    }
}