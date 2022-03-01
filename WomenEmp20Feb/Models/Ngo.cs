using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WomenEmp20Feb.Models
{
    public partial class Ngo
    {
        public Ngo()
        {
            Trainers = new HashSet<Trainer>();
        }

        public int NgoId { get; set; }

        [Required]
        [Display(Name = "NGO Name")]
        public string? NgoName { get; set; }

        [Required]
        [Display(Name = "Contact Person")]
        public string? ContactPerson { get; set; }

        [Required]
        [Display(Name = "Contact Number")]
        public string? NgoContactNumber { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string? NgoAddress { get; set; }

        [Required]
        [Display(Name = "City")]
        public string? NgoCity { get; set; }

        [Required]
        [Display(Name = "State")]
        public string? NgoState { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string? NgoDescription { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string? NgoEmail { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string? NgoPassword { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Confirmation Password is required.")]
        [Compare("NgoPassword", ErrorMessage = "Password and Confirmation Password must match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Supporting Document")]
        public string? NgoSupportingdocument { get; set; }

       
        public bool? Status { get; set; }

        
        public string? Approvedstatus { get; set; }

        public virtual ICollection<Trainer> Trainers { get; set; }


     // public HttpPostedFileBase ImageFile { get; set; }
    }
}
