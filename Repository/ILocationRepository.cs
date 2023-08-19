using bookingdotcom.Models;
using bookingdotcom.ViewModels;

namespace bookingdotcom.Repository
{
    public interface ILocationRepository 
    {
        Task<List<Location>> FilterByDestination(string? destination="");
        Task<Location?> CreateNewLocation(LocationModel model);
        Task<List<string>> GetLocationImgList(int location_id);
        Task<Location?> GetLocationById(int location_id);
        Task<Boolean> DeleteLocationById(int location_id);
    }
}