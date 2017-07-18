using System;
namespace AlphaThea.Models
{
    public class Attendance
    {

        public int LateAm { get; set; }
        public int AbsentAm { get; set; }
        public int AbsentPm { get; set; }
        public DateTime Created { get; set; }

    }
}
