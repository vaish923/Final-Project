using System;
using System.Collections.Generic;

namespace WomenEmp20Feb.Models
{
    public partial class Course
    {
        public Course()
        {
            Enrollments = new HashSet<Enrollment>();
        }

        public int CourseId { get; set; }
        public string CourseName { get; set; } = null!;
        public string? CourseDescription { get; set; }
        public DateTime CourseStartDate { get; set; }
        public DateTime CourseEndDate { get; set; }
        public int IntitialSeats { get; set; }
        public float? Currentseats { get; set; }
        public int? TrainerId { get; set; }
        public bool? Status { get; set; }
        public int? Coursecategory { get; set; }
        public string? Approvedstatus { get; set; }

        public virtual Coursecategory? CoursecategoryNavigation { get; set; }
        public virtual Trainer? Trainer { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
