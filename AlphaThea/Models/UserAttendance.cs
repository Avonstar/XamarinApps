using System;
namespace AlphaThea.Models
{
    public class UserAttendance
    {
		public int id { get; set; }
		public bool lateAm { get; set; }
        public User awardedTo { get; set; }
        public string lateAmTime { get; set; }
		public bool absentAm { get; set; }
        public bool absentPm { get; set; }
		public string created { get; set; }
    }
}
