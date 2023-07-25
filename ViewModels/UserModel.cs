namespace bookingdotcom.ViewModels
{
    public class UserModel 
    {
        public string HashedPassword="";
        public string Email ="";

        public string Phone="";

        public DateTime? DateOfBirth { get; set; }
        public string Country ="";

        public string DisplayName="";

        public bool? Salutation { get; set; }
        public string LastName ="";

        public string FirstName ="";

        public string Address="";


        public string City ="";

        public string PostalCode="";
    }
}