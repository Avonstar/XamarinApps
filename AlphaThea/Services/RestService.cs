using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using AlphaThea.Models;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace AlphaThea.Services
{
    public class RestService : IRestService
    {

        private string _user;
        private string _password;
        private HttpClient _client;
        private string _token;

        public RestService()
        {
            _client = new HttpClient();
            _user = Constants.Username;
            _password = Constants.Password;
        }

        public async Task GetAllLessonGroupsAsync()
        {
            try
            {
				if (!string.IsNullOrWhiteSpace(_token))
				{
					_client.DefaultRequestHeaders.Clear();
					_client.DefaultRequestHeaders.Add("username", _user);
					_client.DefaultRequestHeaders.Add("password", _password);
					_client.DefaultRequestHeaders.Add("token", _token);

				}

				var response = _client.GetAsync(Constants.LessonGroupsUrl).Result;

				var result = await response.Content.ReadAsStringAsync();

				App.Current.Properties.Remove("AllLessonGroups");

				App.Current.Properties.Add("AllLessonGroups", result);
                
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public async Task GetAllPupilsAsync()
        {
			try
			{

				if (!string.IsNullOrWhiteSpace(_token))
				{
					_client.DefaultRequestHeaders.Clear();
					_client.DefaultRequestHeaders.Add("username", _user);
					_client.DefaultRequestHeaders.Add("password", _password);
					_client.DefaultRequestHeaders.Add("token", _token);

				}

				//var response = _client.GetAsync(Constants.AllUsersUrl).Result;
                var response = _client.GetAsync(Constants.AllPupilsUrl).Result;

				var result = await response.Content.ReadAsStringAsync();

                App.Current.Properties.Remove("AllPupils");

				App.Current.Properties.Add("AllPupils", result);


			}
			catch (Exception ex)
			{

				throw new Exception(ex.Message);

			}
        }

        public async Task<ObservableCollection<DisplayHomework>> GetHomeworkAsync(DateTime StartDate, DateTime EndDate, List<string> GroupIds)
        {

			try
			{
				if (!string.IsNullOrWhiteSpace(_token))
				{
					_client.DefaultRequestHeaders.Clear();
					_client.DefaultRequestHeaders.Add("username", _user);
					_client.DefaultRequestHeaders.Add("password", _password);
					_client.DefaultRequestHeaders.Add("token", _token);

				}

                //string fromDate = "2017-03-01";
                //string toDate = "2017-04-01";
                string fromDate = StartDate.ToString("yyyy-MM-dd");
                string toDate = EndDate.ToString("yyyy-MM-dd");

				var specifichomeworkurl = Constants.SpecificHmkBtwnDatesUrl.Replace("fromDate", fromDate);
                specifichomeworkurl = specifichomeworkurl.Replace("toDate", toDate);

                var masterhomeworklist = new List<DisplayHomework>();

                foreach (var grpId in GroupIds)
                {

                    var grpIdHmwkUrl = specifichomeworkurl.Replace("XXXX", grpId);

                    HttpResponseMessage response = _client.GetAsync(grpIdHmwkUrl).Result;

                    var result = await response.Content.ReadAsStringAsync();

                    var homework = new List<DisplayHomework>();

                    homework = JsonConvert.DeserializeObject<List<DisplayHomework>>(result);

                    foreach(var item in homework)
                    {
                        item.body=(Regex.Replace(item.body.ToString(), "<(.|\n)*?>", "")).Replace("&#39;", "'").Replace("&amp;", "&");
                    }

                    masterhomeworklist.AddRange(homework);

                }

				var allhomework = new ObservableCollection<DisplayHomework>();

				foreach (var item in masterhomeworklist)
				{
					allhomework.Add(new DisplayHomework() { title = item.title, dateSet = item.dateSet, dateDue = item.dateDue, body = item.body });

				}

                return allhomework;

			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}


        }

        //      public async Task<ObservableCollection<DisplayUser>> GetAllStudentsAsync()
        //      {
        //	try
        //	{

        //		if (!string.IsNullOrWhiteSpace(_token))
        //		{
        //			_client.DefaultRequestHeaders.Clear();
        //			_client.DefaultRequestHeaders.Add("username", _user);
        //			_client.DefaultRequestHeaders.Add("password", _password);
        //			_client.DefaultRequestHeaders.Add("token", _token);

        //		}

        //		var response = _client.GetAsync(Constants.AllUsersUrl).Result;

        //		var result = await response.Content.ReadAsStringAsync();

        //              var usrs = new List<User>();

        //		usrs = JsonConvert.DeserializeObject<List<User>>(result);

        //              var students = usrs.Where(u => u.roles.Contains("ROLE_PUPIL"));

        //              //ObservableCollection<User> pupils = new ObservableCollection<User>(students);

        //              var pupils = new ObservableCollection<DisplayUser>();

        //              foreach(var item in students)
        //              {
        //                  pupils.Add(new DisplayUser() { firstName = item.firstName, lastName = item.lastName, uid = item.uid, 
        //                                          email=item.email, fullName=item.firstName+" " + item.lastName});
        //              }

        //		return pupils;
        //	}
        //	catch (Exception ex)
        //	{

        //		throw new Exception(ex.Message);

        //	}

        //}

        public async Task GetTokenAsync()
        {
            var uri = new Uri(Constants.TokenUrl);

            try
            {

                string jsonString = @"{""username"" : ""myusername"", ""password"" : ""mypassword""}";

                jsonString = jsonString.Replace("myusername", _user);
                var jsonData = jsonString.Replace("mypassword", _password);

                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _client.PostAsync(uri, content);

                var result = await response.Content.ReadAsStringAsync();

                Token token = JsonConvert.DeserializeObject<Token>(result);

                _token = token.token;

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Attendance> GetUserAttendanceAsync()
        {
            
			try
			{
                

                if (!string.IsNullOrWhiteSpace(_token))
				{
					_client.DefaultRequestHeaders.Clear();
					_client.DefaultRequestHeaders.Add("username", _user);
					_client.DefaultRequestHeaders.Add("password", _password);
					_client.DefaultRequestHeaders.Add("token", _token);

				}

				string id = null;

				if (Application.Current.Properties.ContainsKey("UserId"))
				{
					id = Application.Current.Properties["UserId"] as string;

				}

				var attendanceurl = Constants.AttendanceUrl.Replace("XXXX", id);
                //var attendanceurl = Constants.AttendanceUrl;

                HttpResponseMessage response = _client.GetAsync(attendanceurl).Result;

                var result = await response.Content.ReadAsStringAsync();

                var usrattendances= new List<UserAttendance>();

                usrattendances = JsonConvert.DeserializeObject<List<UserAttendance>>(result);

                int lateAm = 0;
                int absentAm = 0;
                int absentPm = 0;

				lateAm = usrattendances.Where(u => u.lateAm == true).Count();
				absentAm = usrattendances.Where(u => u.absentAm == true).Count();
				absentPm = usrattendances.Where(u => u.absentPm == true).Count();

                var att = new Attendance();

                att.LateAm = lateAm;
                att.AbsentAm = absentAm;
                att.AbsentPm = absentPm;

				return att;
			}
			catch (Exception ex)
			{

				throw new Exception(ex.Message);

			}

        }

        public async Task<User> GetUserDataAsync()
        {		

            try
            {

                if (!string.IsNullOrWhiteSpace(_token))
                {
                    _client.DefaultRequestHeaders.Clear();
                    _client.DefaultRequestHeaders.Add("username", _user);
                    _client.DefaultRequestHeaders.Add("password", _password);
                    _client.DefaultRequestHeaders.Add("token", _token);

                }

                //var response = _client.GetAsync(Constants.SpecificUserUrl).Result;

                var userurl = Constants.UserUrl;

                var response = _client.GetAsync(userurl).Result;

                var result = await response.Content.ReadAsStringAsync();

                var usr = new User();

                usr = JsonConvert.DeserializeObject<User>(result);

                return usr;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }

        }


		public async Task<ObservableCollection<GreenPoints>> GetUserGreenPointsAsync()
		{
			
			try
			{


				if (!string.IsNullOrWhiteSpace(_token))
				{
					_client.DefaultRequestHeaders.Clear();
					_client.DefaultRequestHeaders.Add("username", _user);
					_client.DefaultRequestHeaders.Add("password", _password);
					_client.DefaultRequestHeaders.Add("token", _token);

				}

                string id=null;

                if(Application.Current.Properties.ContainsKey("UserId"))
                {
                    id = Application.Current.Properties["UserId"] as string;

                }

                var greenpointsurl = Constants.GreenPointsUrl.Replace("XXXX", id);

				HttpResponseMessage response = _client.GetAsync(greenpointsurl).Result;

				var result = await response.Content.ReadAsStringAsync();

				var usrgreenpoints = new List<UserGreenPoints>();

				usrgreenpoints = JsonConvert.DeserializeObject<List<UserGreenPoints>>(result);

                //var greenpoints = new List<GreenPoints>();

                var greenpoints = new ObservableCollection<GreenPoints>();

				foreach (var item in usrgreenpoints)
				{
					greenpoints.Add(new GreenPoints() { Created = item.created, AwardedBy = item.approvedBy.username, Description = item.description, Points = item.points });

				}

				return greenpoints;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			
		}

    }
}
