using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using AlphaThea.Models;

namespace AlphaThea.Services
{
    public interface IRestService
    {
        Task<User> GetUserDataAsync();

        //Task<List<UserAttendance>> GetUserAttendanceAsync();
        Task<Attendance> GetUserAttendanceAsync();

    }
}
