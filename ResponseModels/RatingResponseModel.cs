namespace bookingdotcom.ResponseModels
{
    public class RatingResponseModel
    {
        public int RatingId { get; set; }
        public string Comment { get; set; }="";
        public string UserName{set;get;}="";
        public string UserCountry{set;get;}="";
        public string UserAvatar{set;get;}="";
    }
}