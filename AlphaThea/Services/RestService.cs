using System;
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
        public RestService()
        {
            
        }

        public async Task<User> GetUserDataAsync()
        {
			var client = new HttpClient();
			var uri = new Uri(Constants.TokenUrl);
            string user = Constants.Username;
			string password = Constants.Password;

            try
            {

                string jsonString = @"{""username"" : ""myusername"", ""password"" : ""mypassword""}";

                jsonString = jsonString.Replace("myusername", user);
                var jsonData = jsonString.Replace("mypassword", password);

                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(uri, content);

                // this result string should be something like: "{"token":"rgh2ghgdsfds"}"
                var result = await response.Content.ReadAsStringAsync();

                Token token = JsonConvert.DeserializeObject<Token>(result);
                var tok = token.token;

                try
                {

                    if (!string.IsNullOrWhiteSpace(tok))
                    {
                        client.DefaultRequestHeaders.Clear();
                        client.DefaultRequestHeaders.Add("username", Constants.Username);
                        client.DefaultRequestHeaders.Add("password", Constants.Username);
                        client.DefaultRequestHeaders.Add("token", tok);

                    }

                    response = client.GetAsync(Constants.SpecificUserUrl).Result;

                    //return response.Content.ReadAsStringAsync().Result;
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
