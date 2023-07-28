using bookingdotcom.Models;
using bookingdotcom.ViewModels;

namespace bookingdotcom.Repository
{
    public interface IRoomRepository 
    {
        Task<Room?> CreateRoom(int location_id,RoomModel model);
    }
}