using System;
using System.Threading.Tasks;

namespace AlphaThea.Services
{
    public class UserDataManager
    {

        IRestService restService;

        public UserDataManager(IRestService service)
        {
            restService = service;
        }

        public Task<User> RefreshUserDataAsync()
        {

            return restService.GetUserDataAsync();

        }


    }
}
