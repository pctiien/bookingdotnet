namespace bookingdotcom.RequestModels
{
    public class Children{
        public Children(){
            Age = 17;
            ChildrenQuantity =0;
        }
        public int Age {set;get;}
        public int ChildrenQuantity{set;get;}
    }
    public class LocationRequestModel 
    {
        public string Destination {set;get;}="";
        public DateTime StartDate{set;get;} = DateTime.Today;
        public DateTime EndDate{set;get;} = DateTime.Today.AddDays(1);
        public int RoomQuantity{set;get;} = 1;
        public int AdultQuantity{set;get;} = 1;
        public Children Children{set;get;} = new Children();
    }
}