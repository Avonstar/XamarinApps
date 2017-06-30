using System;
using System.Threading.Tasks;

namespace AlphaThea.Services
{
    public interface IRestService
    {
        Task<User> GetUserDataAsync();


    }
}
