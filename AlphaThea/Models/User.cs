using System.Collections.ObjectModel;

namespace AlphaThea.Models
{
    public class User
    {
        
        public int uid { get; set; }
		public string username { get; set; }
		public string email { get; set; }
		public bool status { get; set; }
		public string firstName { get; set; }
		public string lastName { get; set; }
		public string[] roles { get; set; }
        public string[] groupNodeIds { get; set; }

        public string fullName { get; set; }
	}
}