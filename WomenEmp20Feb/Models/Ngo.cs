using System;
using System.Collections.Generic;

namespace WomenEmp20Feb.Models
{
    public partial class Ngo
    {
        public Ngo()
        {
            Trainers = new HashSet<Trainer>();
        }

        public int NgoId { get; set; }
        public string? NgoName { get; set; }
        public string? ContactPerson { get; set; }
        public string? NgoContactNumber { get; set; }
        public string? NgoAddress { get; set; }
        public string? NgoCity { get; set; }
        public string? NgoState { get; set; }
        public string? NgoDescription { get; set; }
        public string? NgoEmail { get; set; }
        public string? NgoPassword { get; set; }
        public string? NgoSupportingdocument { get; set; }
        public bool? Status { get; set; }
        public string? Approvedstatus { get; set; }

        public virtual ICollection<Trainer> Trainers { get; set; }
    }
}
