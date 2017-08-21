//Model of user that will be displayed on screen

using System;
namespace AlphaThea.Models
{
	public class DisplayUser
	{

		public int uid { get; set; }
		public string username { get; set; }
		public string email { get; set; }
		public bool status { get; set; }
		public string firstName { get; set; }
		public string lastName { get; set; }

		public string fullName { get; set; }
	}
}
