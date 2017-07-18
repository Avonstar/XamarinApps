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

        public async Task<Attendance> GetUserAttendanceAsync()
        {
            
			try
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

                    HttpResponseMessage response = _client.GetAsync(Constants.AttendanceUrl).Result;

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
			catch (Exception ex)
			{
				//await DisplayAlert("ERROR", ex.Message, "OK");
				throw new Exception(ex.Message);
			}

        }

        public async Task<User> GetUserDataAsync()
        {

			var uri = new Uri(Constants.TokenUrl);

            try
            {

                string jsonString = @"{""username"" : ""myusername"", ""password"" : ""mypassword""}";

                jsonString = jsonString.Replace("myusername", _user);
                var jsonData = jsonString.Replace("mypassword", _password);

                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _client.PostAsync(uri, content);

                // this result string should be something like: "{"token":"rgh2ghgdsfds"}"
                var result = await response.Content.ReadAsStringAsync();

                Token token = JsonConvert.DeserializeObject<Token>(result);
                //var tok = token.token;
                _token = token.token;

                try
                {

                    if (!string.IsNullOrWhiteSpace(_token))
                    {
                        _client.DefaultRequestHeaders.Clear();
                        _client.DefaultRequestHeaders.Add("username", _user);
                        _client.DefaultRequestHeaders.Add("password", _password);
                        _client.DefaultRequestHeaders.Add("token", _token);

                    }

                    response = _client.GetAsync(Constants.SpecificUserUrl).Result;

                    result = await response.Content.ReadAsStringAsync();

                    var usr = new User();
                    //Users = new List<User>();

                    usr = JsonConvert.DeserializeObject<User>(result);

                    return usr;
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);

                }


            }
            catch (Exception ex)
            {
                //await DisplayAlert("ERROR", ex.Message, "OK");
                throw new Exception(ex.Message);
	        }

        }

   //     public async Task<List<GreenPoints>> GetUserGreenPointsAsync()
   //     {
			//try
			//{

			//	try
			//	{


			//		if (!string.IsNullOrWhiteSpace(_token))
			//		{
			//			_client.DefaultRequestHeaders.Clear();
			//			_client.DefaultRequestHeaders.Add("username", _user);
			//			_client.DefaultRequestHeaders.Add("password", _password);
			//			_client.DefaultRequestHeaders.Add("token", _token);

			//		}

			//		HttpResponseMessage response = _client.GetAsync(Constants.GreenPointsUrl).Result;

			//		var result = await response.Content.ReadAsStringAsync();

			//		var usrgreenpoints = new List<UserGreenPoints>();

			//		usrgreenpoints = JsonConvert.DeserializeObject<List<UserGreenPoints>>(result);

   //                 var greenpoints = new List<GreenPoints>();


   //                 foreach (var item in usrgreenpoints)
   //                 {
   //                     greenpoints.Add(new GreenPoints(){awardedBy=item.approvedBy.username, points=item.points, description=item.description});

   //                 }


			//		return greenpoints;
			//	}
			//	catch (Exception ex)
			//	{
                    

			//		throw new Exception(ex.Message);

			//	}


			//}
			//catch (Exception ex)
			//{
			//	//await DisplayAlert("ERROR", ex.Message, "OK");
			//	throw new Exception(ex.Message);
			//}
        //}

		public async Task<ObservableCollection<GreenPoints>> GetUserGreenPointsAsync()
		{
			try
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

					HttpResponseMessage response = _client.GetAsync(Constants.GreenPointsUrl).Result;

					var result = await response.Content.ReadAsStringAsync();

					var usrgreenpoints = new List<UserGreenPoints>();

					usrgreenpoints = JsonConvert.DeserializeObject<List<UserGreenPoints>>(result);

                    //var greenpoints = new List<GreenPoints>();

                    var greenpoints = new ObservableCollection<GreenPoints>();

					foreach (var item in usrgreenpoints)
					{
						greenpoints.Add(new GreenPoints() { created = item.created, awardedBy = item.approvedBy.username, description = item.description, points = item.points });

					}


					return greenpoints;
				}
				catch (Exception ex)
				{


					throw new Exception(ex.Message);

				}


			}
			catch (Exception ex)
			{
				//await DisplayAlert("ERROR", ex.Message, "OK");
				throw new Exception(ex.Message);
			}
		}

    }
}
