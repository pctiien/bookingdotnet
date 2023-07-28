using bookingdotcom.Models;
using bookingdotcom.ViewModels;

namespace bookingdotcom.Services
{
    public interface IRoomService
    {
        Task<Room?> CreateRoom(int location_id,RoomModel model);
    }
}