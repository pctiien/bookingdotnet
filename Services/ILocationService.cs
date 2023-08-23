using bookingdotcom.Models;
using bookingdotcom.RequestModels;
using bookingdotcom.ResponseModels;
using bookingdotcom.ViewModels;

namespace bookingdotcom.Services
{
    public interface ILocationService 
    {
        Task<List<LocationResponseModel>?> GetLocation(LocationRequestModel model);
        Task<Location?> Create(LocationModel model);
        Task<List<string>> GetLocationImgList(int location_id);
        Task<Location?> GetLocationById(int location_id);
        Task<Boolean> Delete(int location_id);
    }
}