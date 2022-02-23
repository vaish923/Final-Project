using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WomenEmp20Feb.Models
{
    public partial class Woman
    {
        public Woman()
        {
            Enrollments = new HashSet<Enrollment>();
            Feedbacks = new HashSet<Feedback>();
        }

        public int WomenId { get; set; }

        [Required]
        [Display(Name = "Womens Name")]
        public string? WomenFullName { get; set; }

        [Required]
        [Display(Name = "Contact No.")]
        public string? WomenContactNumber { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string? WomenAddress { get; set; }

        [Required]
        [Display(Name = "City")]
        public string? WomenCity { get; set; }

        [Required]
        [Display(Name = "State")]
        public string? WomenState { get; set; }

        [Required]
        [Display(Name = "Father's Name")]
        public string? WomenFathername { get; set; }

        [Required]
        [Display(Name = "Mother's Name")]
        public string? WomenMothername { get; set; }

        [Required]
        [Display(Name = "Spouse Name")]
        public string? WomenSpousename { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string? WomenEmail { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be atleast of {2} characters long", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string? WomenPassword { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Confirmation Password is required.")]
        [Compare("WomenPassword", ErrorMessage = "Password and Confirmation Password must match.")]
        public string ConfirmPassword { get; set; }


        [Required]
        [Display(Name = "Aadhar Card")]
        public string? WomenDocument { get; set; }

       
        public bool? Status { get; set; }

        [Required]
        [Display(Name = "Marital Status")]
        public string? WomenMaritalStatus { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}
