using bookingdotcom.Models;
using bookingdotcom.Repository;
using bookingdotcom.ViewModels;

namespace bookingdotcom.Services
{
    public class UserService : IUserService
    {
        public IUserRepository _IUserRepository;
        public UserService(IUserRepository IUserRepository)
        {
            _IUserRepository = IUserRepository;
        }
        public async Task<User> Register(UserModel model)
        {
           var userExistingByEmail = await _IUserRepository.GetUserByEmail(model.Email??"");
           if(userExistingByEmail!=null)
           {
                throw new ArgumentException("Email already exists");
           }
           Console.WriteLine("xong rui`");
           return await _IUserRepository.Create(model);

        }
    }
}