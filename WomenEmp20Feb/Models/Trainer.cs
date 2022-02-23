using System;
using System.Collections.Generic;

namespace WomenEmp20Feb.Models
{
    public partial class Trainer
    {
        public Trainer()
        {
            Courses = new HashSet<Course>();
        }

        public int TrainerId { get; set; }
        public string? TrainerFullName { get; set; }
        public string? TrainerContactNumber { get; set; }
        public string? TrainerEmail { get; set; }
        public int? NgoId { get; set; }

        public virtual Ngo? Ngo { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
