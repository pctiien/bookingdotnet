using bookingdotcom.Models;
using bookingdotcom.ViewModels;

namespace bookingdotcom.Repository
{
    public interface IUserRepository 
    {
        Task<User?> GetUserById(int id);
        Task<User?> GetUserByEmail(string email);
        Task<User?> Create(UserModel model);
    }
}