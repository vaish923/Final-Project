using System;
using System.Collections.Generic;

namespace WomenEmp20Feb.Models
{
    public partial class Feedback
    {
        public int FeedbackId { get; set; }
        public DateTime? FeedbackDate { get; set; }
        public string? FeedbackDescription { get; set; }
        public int? WomenId { get; set; }

        public virtual Woman? Women { get; set; }
    }
}
