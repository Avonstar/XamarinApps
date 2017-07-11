using System;
namespace AlphaThea.Models
{
    public class AttendancePieEntity
    {
        public string Name { get; set; }

		public double Value { get; set; }

		public AttendancePieEntity(string name, double value)
		{
			this.Name = name;
			this.Value = value;
		}

    }
}
