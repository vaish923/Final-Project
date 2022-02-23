using System;
using System.Collections.Generic;

namespace WomenEmp20Feb.Models
{
    public partial class Enrollment
    {
        public int WomenId { get; set; }
        public int CourseId { get; set; }
        public DateTime? Enrollmentdate { get; set; }
        public string? ApprovalStatus { get; set; }
        public DateTime? ApprovalDate { get; set; }

        public virtual Course Course { get; set; } = null!;
        public virtual Woman Women { get; set; } = null!;
    }
}
