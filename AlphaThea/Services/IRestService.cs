using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using AlphaThea.Models;
using System.Collections.ObjectModel;

namespace AlphaThea.Services
{
    public interface IRestService
    {

        Task GetTokenAsync();

        Task<ObservableCollection<DisplayUser>> GetAllStudentsAsync();

        Task GetAllPupilsAsync();

        Task<User> GetUserDataAsync();

        //Task<List<UserAttendance>> GetUserAttendanceAsync();
        Task<Attendance> GetUserAttendanceAsync();

        //Task<List<GreenPoints>> GetUserGreenPointsAsync();

        Task<ObservableCollection<GreenPoints>> GetUserGreenPointsAsync();


    }
}
