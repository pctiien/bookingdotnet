using bookingdotcom.Models;
using bookingdotcom.ViewModels;

namespace bookingdotcom.Services
{
    public interface ILocationService 
    {
        Task<List<Location>> GetLocation(string destination);
        Task<Location?> Create(LocationModel model);
        Task<List<string>> GetLocationImgList(int location_id);
        Task<Location?> GetLocationById(int location_id);
    }
}