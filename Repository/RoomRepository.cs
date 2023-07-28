using bookingdotcom.Models;
using bookingdotcom.ViewModels;

namespace bookingdotcom.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly BookingDbContext _DbContext;
        public RoomRepository(BookingDbContext DbContext)
        {
            _DbContext = DbContext;
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
                if(model.UnavailableDates!=null)
                {
                    // convert unavailabledatesmodel to unavailabledates
                    var un_availabledate = model.UnavailableDates.Select(ud=>new UnavailableDate{
                    Unavailable_Date = ud.Unavailable_Date,
                    RoomId = room.RoomId
                    }).ToList();
                    await _DbContext.UnavailableDates.AddRangeAsync(un_availabledate);
                    await _DbContext.SaveChangesAsync();
                }
                if(model.BedTypes!=null)
                {
                    var bedtypes = model.BedTypes.Select(bt=>new BedType{
                        RoomId = room.RoomId,
                        BedTypeName = bt.BedTypeName
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