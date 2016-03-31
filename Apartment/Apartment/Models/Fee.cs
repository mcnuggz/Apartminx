using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apartment.Models
{
    public class Fee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public int PetCostId { get; set; }
        public virtual PetCost PetCost { get; set; }
        public int ResidentId { get; set; }
        public virtual Resident Resident { get; set; }
    }
}