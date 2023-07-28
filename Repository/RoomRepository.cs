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
        public async Task<Room?> CreateRoom(RoomModel model)
        {
            if(model!=null)
            {
                var room = new Room{
                LocationId = model.LocationId,
                RoomName = model.RoomName,
                };
                await _DbContext.Rooms.AddAsync(room);
                await _DbContext.SaveChangesAsync();
                if(model.UnavailableDates!=null)
                {
                    var un_availabledate = model.UnavailableDates.Select(ud=>new UnavailableDate{
                    Unavailable_Date = ud.Unavailable_Date,
                    RoomId = ud.RoomId
                    }).ToList();
                    await _DbContext.UnavailableDates.AddRangeAsync(un_availabledate);
                    await _DbContext.SaveChangesAsync();
                }
                if(model.BedTypes!=null)
                {
                    var bedtypes = model.BedTypes.Select(bt=>new BedType{
                        RoomId = bt.RoomId,
                        BedTypeName = bt.BedTypeName
                    });
                    await _DbContext.BedTypes.AddRangeAsync(bedtypes);
                    await _DbContext.SaveChangesAsync();
                    foreach(var rb in model.BedTypes)
                    {
                        if(rb!=null)
                        {
                            var roombed = new RoomBed{
                            BedQuantity = rb.RoomBed.BedQuantity,
                            BedTypeId = rb.RoomBed.BedTypeId
                            };
                            await _DbContext.RoomBeds.AddAsync(roombed);
                            await _DbContext.SaveChangesAsync();
                        }
                    }
                }
                _DbContext.Rooms.Entry(room)
                .Collection(r => r.BedTypes)
                .Load();

                _DbContext.Rooms.Entry(room)
                .Collection(r => r.UnvailableDates)
                .Load();
                return room;
            }else
            {
                throw new ArgumentNullException("Model cannot be null");
            }
        }
    }
}