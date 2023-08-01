using System.Text.Json;
using System.Text.Json.Serialization;
using bookingdotcom.Models;
using bookingdotcom.Services;
using bookingdotcom.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace bookingdotcom.Repository
{
    public class LocationRepository : ILocationRepository
    {
        public IAzureService _IAzureService{set;get;}
        private readonly BookingDbContext _DbContext;
        public LocationRepository(BookingDbContext DbContext,IAzureService IAzureService)
        {
            _DbContext = DbContext;
            _IAzureService = IAzureService;
        }
        public async Task<Location?> CreateNewLocation(LocationModel model)
        {
            var posterUrl ="";
            if(model.Poster!=null)
            {
                posterUrl = await _IAzureService.UploadLocationPoster(model.Poster);
            }
            var location = new Location
            {
                LocationName = model.LocationName,
                City = model.City,
                Country = model.City,
                Description = model.Description,
                Address = model.Address,
                Poster = posterUrl??""
            };
            await _DbContext.Locations.AddAsync(location);
            await _DbContext.SaveChangesAsync();
            var locationImgs = new List<string?>();
            if(model.LocationImgs!=null)
            {
                locationImgs = await _IAzureService.UploadLocationImages(model.LocationImgs);
                var result = locationImgs?.Where(li=>li!=null).Select(li=>new LocationImage {
                    LocationId =  location.LocationId,
                    LocationImageUrl = li??""
                });
                if(result!=null)
                {
                    await _DbContext.LocationImages.AddRangeAsync(result);
                    await _DbContext.SaveChangesAsync();
                }
            }
            return location;
        }

        public async Task<List<Location>> FilterByDestination(string destination)
        {
            var locations = await _DbContext.Locations
                .Where(lo => lo.City.Contains(destination)
                        || lo.Country.Contains(destination)
                        || lo.LocationName.Contains(destination)
                        || lo.Address.Contains(destination)
                        || lo.Description.Contains(destination))
                .Include(lo=>lo.Discount).Include(lo=>lo.Ratings)
                .ToListAsync();
            return locations;
        }

        public async Task<List<string>> GetLocationImgList(int location_id)
        {
            var imgList = await _DbContext.LocationImages.Where(li=>li.LocationId==location_id).Select(li=>li.LocationImageUrl).ToListAsync();
            return imgList;
        }
    }
}