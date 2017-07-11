using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AlphaThea.Models;

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

        public Task<Attendance> RefreshUserAttendanceAsync()
        {

            return restService.GetUserAttendanceAsync();

        }

    }
}
