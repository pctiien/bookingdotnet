using bookingdotcom.Models;
using bookingdotcom.ViewModels;

namespace bookingdotcom.Services
{
    public interface IUserService
    {
        Task<User> Register(UserModel model);
        Task<User> Login(LoginModel model);
    }
}