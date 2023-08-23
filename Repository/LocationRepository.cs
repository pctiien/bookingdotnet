using System.Text.Json;
using System.Text.Json.Serialization;
using bookingdotcom.Models;
using bookingdotcom.RequestModels;
using bookingdotcom.ResponseModels;
using bookingdotcom.Services;
using bookingdotcom.ViewModels;
using Google.Protobuf.WellKnownTypes;
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

        public async Task<List<LocationResponseModel>?> FilterByDestination(LocationRequestModel model)
        {
                var result = await _DbContext.Locations.Include(l=>l.RoomTypes).Include(l=>l.Rooms)
                .Where(lo => lo.City.Contains(model.Destination)
                        || lo.Country.Contains(model.Destination)
                        || lo.LocationName.Contains(model.Destination)
                        || lo.Address.Contains(model.Destination)
                        || lo.Description.Contains(model.Destination))
                .Where(l =>l.RoomTypes!=null&& l.RoomTypes.Any(rt =>rt!=null&& rt.MaxOccupancy > model.AdultQuantity))
                .Select(l=>new LocationResponseModel{
                            LocationId = l.LocationId,
                            Country = l.Country,
                            City = l.City,
                            Description = l.Description,
                            Discount = l.Discount!=null?l.Discount.DiscountAmount:0,
                            Poster = l.Poster,
                            Rating = l.Ratings!.Average(r=>r!=null?r.Score:0)
                        }).ToListAsync();

                return result;
        }

        public async Task<List<string>> GetLocationImgList(int location_id)
        {
            var imgList = await _DbContext.LocationImages.Where(li=>li.LocationId==location_id).Select(li=>li.LocationImageUrl).ToListAsync();
            return imgList;
        }

        public async Task<Location?> GetLocationById(int location_id)
        {
            return await _DbContext.Locations.FirstOrDefaultAsync(lo=>lo.LocationId==location_id);
        }

        public async Task<bool> DeleteLocationById(int location_id)
        {
            var res = await _DbContext.Locations.FirstOrDefaultAsync(lo=>lo.LocationId==location_id);
            if(res==null) return false;
            else
            {
                _DbContext.Locations.Remove(res);
                return true;
            }

        }
    }
}