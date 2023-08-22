using bookingdotcom.Models;
using bookingdotcom.Services;
using bookingdotcom.ViewModels;

namespace bookingdotcom.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly BookingDbContext _DbContext;
        public IAzureService _IAzureService{set;get;}
        public RoomRepository(BookingDbContext DbContext,IAzureService IAzureService)
        {
            _DbContext = DbContext;
            _IAzureService = IAzureService;
        }
        public async Task<Room?> CreateRoom(RoomModel model)
        {
            if(model!=null)
            {
                // Convert roommodel to room
                var room = new Room{
                RoomSize = model.RoomSize,
                Price = model.Price,
                LocationId = model.LocationId,
                RoomTypeId = model.RoomTypeId
                };
                await _DbContext.Rooms.AddAsync(room);
                await _DbContext.SaveChangesAsync();     
                if(model.FacilityIds!=null)
                {
                    var roomFacilityLinks = model.FacilityIds.Select(id=>new RoomFacilityLink {
                        RoomId = room.RoomId,
                        FacilityId = id
                    }).ToList();
                    await _DbContext.RoomFacilityLinks.AddRangeAsync(roomFacilityLinks);
                    await _DbContext.SaveChangesAsync();
                } 
                if(model.BedTypes!=null)
                {
                    var bedtypes = model.BedTypes.Select(bt=>new BedType{
                        RoomId = room.RoomId,
                        BedTypeName = bt?.BedTypeName??""
                    }).ToList();
                        await _DbContext.BedTypes.AddRangeAsync(bedtypes);
                        await _DbContext.SaveChangesAsync();
                    var btlist = bedtypes;    
                }
                return room;
            }else
            {
                throw new ArgumentNullException("Model cannot be null");
            }
        }
    }
}