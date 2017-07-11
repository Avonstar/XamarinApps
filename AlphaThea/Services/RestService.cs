using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using AlphaThea.Models;

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

        public async Task<List<UserAttendance>> GetUserAttendanceAsync()
        {
            
			try
			{

				try
				{
                    
					HttpResponseMessage response = _client.GetAsync(Constants.AttendanceUrl).Result;

                    var result = await response.Content.ReadAsStringAsync();

                    var usrattendances= new List<UserAttendance>();

                    usrattendances = JsonConvert.DeserializeObject<List<UserAttendance>>(result);

					return usrattendances;
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
			//var client = new HttpClient();

			var uri = new Uri(Constants.TokenUrl);
            //string user = Constants.Username;

			//string password = Constants.Password;

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

    }
}
