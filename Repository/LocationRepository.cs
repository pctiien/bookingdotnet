using System.Text.Json;
using System.Text.Json.Serialization;
using bookingdotcom.Models;
using bookingdotcom.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace bookingdotcom.Repository
{
    public class LocationRepository : ILocationRepository
    {
        private readonly BookingDbContext _DbContext;
        public LocationRepository(BookingDbContext DbContext)
        {
            _DbContext = DbContext;
        }
        public async Task<Location?> CreateNewLocation(LocationModel model)
        {
            var location = new Location
            {
                LocationName = model.LocationName,
                City = model.City,
                Country = model.City,
                Description = model.Description,
                Address = model.Address
            };
            await _DbContext.Locations.AddAsync(location);
            await _DbContext.SaveChangesAsync();
            return location;
        }

        public async Task<List<Location?>?> FilterByDestination(string destination)
        {
            var locations = await _DbContext.Locations
                .Where(lo => lo.City.Contains(destination)
                        || lo.Country.Contains(destination)
                        || lo.LocationName.Contains(destination)
                        || lo.Address.Contains(destination)
                        || lo.Description.Contains(destination))
                .Include(lo=>lo.Discount)
                .ToListAsync();
            return locations;
        }
    }
}