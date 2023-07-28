using bookingdotcom.Models;
using bookingdotcom.Repository;
using bookingdotcom.ViewModels;

namespace bookingdotcom.Services
{
    public class RoomService : IRoomService
    {
        public IRoomRepository _IRoomRepository {set;get;}
        public RoomService(IRoomRepository IRoomRepository)
        {
            _IRoomRepository = IRoomRepository;
        }
        public async Task<Room?> CreateRoom(int location_id,RoomModel model)
        {
            return await _IRoomRepository.CreateRoom(location_id,model);
        }

    }
}