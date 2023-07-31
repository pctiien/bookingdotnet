using bookingdotcom.Models;
using bookingdotcom.Repository;
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

        public async Task<List<Location>> GetLocation(string destination)
        {
            
            return await _ILocationRepository.FilterByDestination(destination);
        }
    }
}