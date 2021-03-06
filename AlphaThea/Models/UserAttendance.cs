﻿using System;
namespace AlphaThea.Models
{

    //Models the user attendance data returned as JSON

    public class UserAttendance
    {
		public int id { get; set; }
		public bool lateAm { get; set; }
        public User awardedTo { get; set; }
        public string lateAmTime { get; set; }
		public bool absentAm { get; set; }
        public bool absentPm { get; set; }
		public DateTime created { get; set; }
    }
}
