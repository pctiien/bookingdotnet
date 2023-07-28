using bookingdotcom.Models;
using bookingdotcom.ViewModels;

namespace bookingdotcom.Repository
{
    public interface IRoomRepository 
    {
        Task<Room?> CreateRoom(RoomModel model);
    }
}