using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bookingdotcom.ViewModels
{
    public class RoomTypeModel{
        public int MaxOccupancy{set;get;}
        public int LocationId{set;get;}
        public int RoomTypeNameId{set;get;}
        public IFormFile[]? Imgs{set;get;}
    }
}