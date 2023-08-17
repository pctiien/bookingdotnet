    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using bookingdotcom.Models;

    namespace bookingdotcom.ViewModels
    {
        public class RoomModel
        {

            [Required]
            public string RoomName { get; set; }="";
            public float RoomSize{set;get;}
            public float Price{set;get;}
            public IFormFile[]? RoomImages{set;get;}
            public virtual ICollection<BedTypeModel?>? BedTypes{set;get;}
            public virtual ICollection<int>? FacilityIds{set;get;}
        }
    }