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

        public Task<List<Location?>?> GetLocation(string destination)
        {
            
            return _ILocationRepository.FilterByDestination(destination);
        }
    }
}