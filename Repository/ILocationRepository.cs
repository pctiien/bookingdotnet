using bookingdotcom.Models;
using bookingdotcom.ViewModels;

namespace bookingdotcom.Repository
{
    public interface ILocationRepository 
    {
        Task<List<Location?>?> FilterByDestination(string destination);
        Task<Location?> CreateNewLocation(LocationModel model);
    }
}