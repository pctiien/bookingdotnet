using bookingdotcom.Models;
using bookingdotcom.ViewModels;

namespace bookingdotcom.Repository
{
    public interface IRoomTypeRepository
    {
        Task<RoomType?> CreateRoomType(RoomTypeModel model);
    }
}