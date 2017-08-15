namespace AlphaThea
{

	public static class Constants
	{
		// URL of REST service
		//public static string RestUrl = "http://developer.xamarin.com:8081/api/todoitems/{0}";

		public static string RestUrl = "http://api.s17039536.onlinehome-server.info/web/api/token-authentication";

        public static string TokenUrl = "http://api.s17039536.onlinehome-server.info/web/api/token-authentication";

        public static string UsersUrl = "http://api.s17039536.onlinehome-server.info/web/api/user";

        public static string AllUsersUrl = "http://api.s17039536.onlinehome-server.info/web/api/user/?limit=400&page=1&sort=u.uid&direction=asc";

        //public static string SpecificUserUrl = "http://api.s17039536.onlinehome-server.info/web/api/user/357";

        //public static string SpecificUserUrl = "http://api.s17039536.onlinehome-server.info/web/api/user/1747";
        public static string UserUrl = "http://api.s17039536.onlinehome-server.info/web/api/user/";


        //public static string AttendanceUrl ="http://api.s17039536.onlinehome-server.info/web/api/attendance/?sort=c.created&direction=DESC&userId=UID&limit=180";
        //public static string AttendanceUrl = "http://api.s17039536.onlinehome-server.info/web/api/attendance/?sort=c.created&direction=DESC&userId=1747&limit=180";
		public static string AttendanceUrl = "http://api.s17039536.onlinehome-server.info/web/api/attendance/?sort=c.created&direction=DESC&awardedTo=XXXX&limit=180";


		//"http://api.s17039536.onlinehome-server.info/web/api/attendance/?sort=c.created&direction=DESC&userId=5312&limit=180";
		//http://api.s17039536.onlinehome-server.info/web/api/attendance/?sort=c.created&direction=DESC&userId=1747&limit=180


		//Green points
		//public static string GreenPointsUrl = "http://api.s17039536.onlinehome-server.info/web/api/points/?sort=c.created&direction=DESC&from=2017-01-01&to=2017-09-01&awardedTo=393&type=3";
		public static string GreenPointsUrl = "http://api.s17039536.onlinehome-server.info/web/api/points/?sort=c.created&direction=DESC&from=2017-01-01&to=2017-09-01&awardedTo=XXXX&type=3";


		// Credentials that are hard coded into the REST service
		public static string Username = "radams";
		public static string Password = "London2034";
	}


}