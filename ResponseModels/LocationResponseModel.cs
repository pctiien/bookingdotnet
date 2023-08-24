using bookingdotcom.Models;

namespace bookingdotcom.ResponseModels
{
    public class LocationResponseModel
    {
        public int LocationId { get; set; }

        public string LocationName { get; set; }="";
        public string Country{set;get;}="";

        public string Address { get; set; }="";

        public string? City { get; set; }="";
        public string Description { get; set; }="";
        public string Poster {set;get;}="";
        public float Rating{set;get;} = 0;
        public decimal Discount {set;get;}=0;
        public int RatingQuantity{set;get;}=0;
        public Room? Room{set;get;}
        
    }
}