using System;
namespace AlphaThea.Models
{
	//Models the user attendance data returned as JSON

	public class UserGreenPoints
    {
		public int id { get; set; }
		public User awardedTo { get; set; }
		public User approvedBy { get; set; }
		public int points { get; set; }
		public int type { get; set; }
		public DateTime created { get; set; }
		public string description { get; set; }
		public int entityId { get; set; }
		public string entityType { get; set; }
		public string operation { get; set; }
		public int reasonType { get; set; }
    }
}
