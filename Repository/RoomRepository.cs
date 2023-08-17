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
        public async Task<Room?> CreateRoom(int location_id,RoomModel model)
        {
            if(model!=null)
            {
                // Convert roommodel to room
                var room = new Room{
                LocationId = location_id,
                RoomName = model.RoomName,
                };
                await _DbContext.Rooms.AddAsync(room);
                await _DbContext.SaveChangesAsync();
                if(model.RoomImages!=null)
                {
                    var listImgs = await _IAzureService.UploadRoomImages(model.RoomImages);
                    if(listImgs!=null)
                    {
                        var listRoomImage = listImgs?.Where(li=>li!=null).Select(li=>new RoomImage {
                        RoomImageUrl = li??"",
                        RoomId = room.RoomId
                        });
                        if(listRoomImage!=null)
                        {
                            await _DbContext.RoomImages.AddRangeAsync(listRoomImage);
                            await _DbContext.SaveChangesAsync();
                        }
                    }
                }
                if(model.BedTypes!=null)
                {
                    var bedtypes = model.BedTypes.Select(bt=>new BedType{
                        RoomId = room.RoomId,
                        BedTypeName = bt?.BedTypeName??""
                    }).ToList();
                        // Convert bedtypemodel to bedtype
                        await _DbContext.BedTypes.AddRangeAsync(bedtypes);
                        await _DbContext.SaveChangesAsync();
                    var btlist = bedtypes;
                    var index =0;
                    foreach(var rb in model.BedTypes)
                    {
                        if(rb!=null&&rb.RoomBed!=null)
                        {
                            var roombed = new RoomBed{
                            BedQuantity = rb.RoomBed.BedQuantity,
                            BedTypeId = btlist[index++].BedTypeId
                            };
                            // Convert roombedmodel to roombed
                            await _DbContext.RoomBeds.AddAsync(roombed);
                            await _DbContext.SaveChangesAsync();
                        }
                    }
                }
                return room;
            }else
            {
                throw new ArgumentNullException("Model cannot be null");
            }
        }
    }
}