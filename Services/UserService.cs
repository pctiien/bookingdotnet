using bookingdotcom.Models;
using bookingdotcom.Repository;
using bookingdotcom.ViewModels;
using MySql.Data.MySqlClient;

namespace bookingdotcom.Services
{
    public class UserService : IUserService
    {
        public IUserRepository _IUserRepository;
        public UserService(IUserRepository IUserRepository)
        {
            _IUserRepository = IUserRepository;
        }

        public async Task<string?> Login(LoginModel model)
        {
           var jwtToken = await _IUserRepository.Login(model);
           if(jwtToken!=null)
           {
                return jwtToken;
           }else
           {
                throw new ArgumentException("Email or password is incorrect");
           }
        }

        public async Task<User?> Register(UserModel model)
        {
           var userExistingByEmail = await _IUserRepository.GetUserByEmail(model.Email??"");
           if(userExistingByEmail!=null)
           {
                throw new ArgumentException("Email already exists");
           }
           return await _IUserRepository.Create(model);
        }
    }
}