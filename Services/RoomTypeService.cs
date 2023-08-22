using bookingdotcom.Models;
using bookingdotcom.Repository;
using bookingdotcom.ViewModels;

namespace bookingdotcom.Services
{
    public class RoomTypeService : IRoomTypeService
    {
        public IRoomTypeRepository _IRoomTypeRepository{set;get;}
        public RoomTypeService(IRoomTypeRepository IRoomTypeRepository)
        {
            _IRoomTypeRepository = IRoomTypeRepository;
        }
        public async Task<RoomType?> CreateRoomType(RoomTypeModel model)
        {
            return await _IRoomTypeRepository.CreateRoomType(model);
        }
    }
}