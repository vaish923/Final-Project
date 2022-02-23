using System;
using System.Collections.Generic;

namespace WomenEmp20Feb.Models
{
    public partial class Coursecategory
    {
        public Coursecategory()
        {
            Courses = new HashSet<Course>();
        }

        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
