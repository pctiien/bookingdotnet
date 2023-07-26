using System.ComponentModel.DataAnnotations;

namespace bookingdotcom.ViewModels
{
    public class UserModel 
    {
        [Required(ErrorMessage ="Password is required")]
        public string HashedPassword{set;get;}="";
        [Required]
        [EmailAddress(ErrorMessage ="Invalid email address")]
        public string Email{set;get;}="";

        public string? Phone{set;get;}

        public DateTime? DateOfBirth { get; set; }
        public string? Country{set;get;}

        public string? DisplayName{set;get;}

        public bool? Salutation { set; get; }
        public string? LastName{set;get;}

        public string? FirstName{set;get;}

        public string? Address{set;get;}


        public string?City {set;get;}

        public string? PostalCode{set;get;}
    }
}