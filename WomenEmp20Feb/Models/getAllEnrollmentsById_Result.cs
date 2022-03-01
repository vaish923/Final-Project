namespace WomenEmp20Feb.Models
{
    public class getAllEnrollmentsById_Result
    {
        public int women_id { get; set; }
        public int course_id { get; set; }
        public Nullable<System.DateTime> enrollmentdate { get; set; }
        public string approval_status { get; set; }
        public Nullable<System.DateTime> approval_date { get; set; }

        public virtual Course course { get; set; }
        public virtual Woman woman { get; set; }
    }
}