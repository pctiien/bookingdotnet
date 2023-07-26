using System.ComponentModel.DataAnnotations;

namespace bookingdotcom.ViewModels
{
    public class LoginModel
    {
        [Required]
        [EmailAddress]
        public string Email{set;get;}="";
        [Required]
        public string Password{set;get;}="";
        
    }
}