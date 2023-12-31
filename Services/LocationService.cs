using bookingdotcom.Models;
using bookingdotcom.Repository;
using bookingdotcom.RequestModels;
using bookingdotcom.ResponseModels;
using bookingdotcom.ViewModels;

namespace bookingdotcom.Services
{
    public class LocationService : ILocationService
    {
        public ILocationRepository _ILocationRepository{set;get;}
        public LocationService(ILocationRepository ILocationRepository)
        {
            _ILocationRepository = ILocationRepository;
        }
        public Task<Location?> Create(LocationModel model)
        {

            return _ILocationRepository.CreateNewLocation(model);
        }

        public async Task<List<LocationResponseModel>?> GetLocation(LocationRequestModel model)
        {
            
            return await _ILocationRepository.FilterByDestination(model);
        }

        public async Task<List<string>> GetLocationImgList(int location_id)
        {
            return await _ILocationRepository.GetLocationImgList(location_id);
        }

        public async Task<Location?> GetLocationById(int location_id)
        {
            return await _ILocationRepository.GetLocationById(location_id);
        }

        public async Task<bool> Delete(int location_id)
        {
            return await _ILocationRepository.DeleteLocationById(location_id);
        }
    }
}