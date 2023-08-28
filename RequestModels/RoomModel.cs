    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using bookingdotcom.Models;

    namespace bookingdotcom.ViewModels
    {
        public class RoomModel
        {

            public float RoomSize{set;get;}
            public float Price{set;get;}
            public int LocationId{set;get;}
            public int RoomTypeId{set;get;}
            public virtual ICollection<int>? FacilityIds{set;get;}
        }
    }