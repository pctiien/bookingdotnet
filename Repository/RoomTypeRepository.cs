using bookingdotcom.Models;
using bookingdotcom.Services;
using bookingdotcom.ViewModels;

namespace bookingdotcom.Repository
{
    public class RoomTypeRepository : IRoomTypeRepository
    {
        BookingDbContext _dbContext{set;get;}
        IAzureService _AzureService{set;get;}
        public RoomTypeRepository(BookingDbContext dbContext,IAzureService AzureService)
        {
            _dbContext = dbContext;
            _AzureService = AzureService;
        }
        public async Task<RoomType?> CreateRoomType(RoomTypeModel model)
        {
            var res = new RoomType
            {
                MaxOccupancy = model.MaxOccupancy,
                LocationId = model.LocationId,
                RoomTypeNameId = model.RoomTypeNameId
            };
            await _dbContext.RoomTypes.AddAsync(res);
           // await _dbContext.Entry(res).Reference(rt => rt.RoomTypeName).LoadAsync();
            await _dbContext.SaveChangesAsync();
            var listImgs = model.Imgs;
            if(listImgs!=null)
            {            
               var imgRes =await _AzureService.UploadRoomImages(listImgs);
               if(imgRes!=null)
               {
                var roomImgs = imgRes?.Select(img=>new RoomImg{
                    RoomImageUrl = img??"",
                    RoomTypeId = res.RoomTypeId
                });
               if(roomImgs!=null) 
                await _dbContext.RoomImages.AddRangeAsync(roomImgs);
                await _dbContext.SaveChangesAsync();
               }
            }
            return res;
        }
    }

}