using bookingdotcom.Models;
using bookingdotcom.ViewModels;

namespace bookingdotcom.Services
{
    public interface IRoomTypeService
    {
        Task<RoomType?> CreateRoomType(RoomTypeModel model);
    }
}