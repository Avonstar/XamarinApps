using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

		public Task<ObservableCollection<GreenPoints>> RefreshUserGreenPointsAsync()
		{

			return restService.GetUserGreenPointsAsync();

		}

		public Task<ObservableCollection<User>> RefreshUsersAsync()
		{

			return restService.GetAllStudentsAsync();

		}

		public Task GetPupilsAsync()
		{

			return restService.GetAllPupilsAsync();

		}

        public Task GetNewToken()
        {

            return restService.GetTokenAsync();

        }


    }
}
