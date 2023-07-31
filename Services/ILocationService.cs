using bookingdotcom.Models;
using bookingdotcom.ViewModels;

namespace bookingdotcom.Services
{
    public interface ILocationService 
    {
        Task<List<Location>> GetLocation(string destination);
        Task<Location?> Create(LocationModel model);
    }
}