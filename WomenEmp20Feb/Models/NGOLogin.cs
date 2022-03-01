using System.ComponentModel.DataAnnotations;

namespace WomenEmp20Feb.Models
{
    public class NGOLogin
    {
        [Key]
        public int LogId { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string? Password { get; set; }
    }
}
