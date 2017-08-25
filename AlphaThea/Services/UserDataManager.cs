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

		public Task GetNewToken()
		{

			return restService.GetTokenAsync();

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

		public Task<ObservableCollection<DisplayHomework>> RefreshUserHomeworkAsync(DateTime StartDate, DateTime EndDate, List<string> GroupIds)
		{

			return restService.GetHomeworkAsync(StartDate, EndDate, GroupIds);

		}

		//public Task<ObservableCollection<DisplayUser>> RefreshUsersAsync()
		//{

		//	return restService.GetAllStudentsAsync();

		//}

		public Task GetPupilsAsync()
		{

			return restService.GetAllPupilsAsync();

		}

        public Task GetLessonGroups()
        {

            return restService.GetAllLessonGroupsAsync();

        }


    }
}
