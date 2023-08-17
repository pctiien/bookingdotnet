using bookingdotcom.Models;
using bookingdotcom.Services;
using bookingdotcom.ViewModels;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace bookingdotcom.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly BookingDbContext _dbContext ;
        private readonly IConfiguration _Config;
        private readonly ITokenService _ITokenService;
        public UserRepository(BookingDbContext dbContext,IConfiguration Config,ITokenService ITokenService)
        {
            _dbContext = dbContext;       
            _Config = Config;     
            _ITokenService = ITokenService;
        }
        public async Task<User?> Create(UserModel model)
        {
            string sqlQuery = "CALL Register(@Email, @HashedPassword, @Phone, @DateOfBirth, @Country, @DisplayName, @FirstName, @LastName, @Address, @City, @PostalCode, @Salutation)";

            var parameters = new[]
            {
                new MySqlParameter("@Email", model.Email),
                new MySqlParameter("@HashedPassword", model.HashedPassword),
                new MySqlParameter("@Phone", model.Phone),
                new MySqlParameter("@DateOfBirth", model.DateOfBirth),
                new MySqlParameter("@Country", model.Country),
                new MySqlParameter("@DisplayName", model.DisplayName),
                new MySqlParameter("@FirstName", model.FirstName),
                new MySqlParameter("@LastName", model.LastName),
                new MySqlParameter("@Address", model.Address),
                new MySqlParameter("@City", model.City),
                new MySqlParameter("@PostalCode", model.PostalCode),
                new MySqlParameter("@Salutation",model.Salutation)
            };
            var user =await _dbContext.Users.FromSqlRaw(sqlQuery, parameters).ToListAsync();
            return user.FirstOrDefault();
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            return await  _dbContext.Users.FirstOrDefaultAsync(u=>u.Email == email);
        }

        public async Task<string?> Login(LoginModel model)
        {
            string sqlQuery = "CALL Login(@Email, @Password)";

            var parameters = new[]
            {
                new MySqlParameter("@Email", model.Email),
                new MySqlParameter("@Password", model.Password),
            };
            var result = await _dbContext.Users.FromSqlRaw(sqlQuery, parameters).ToListAsync();
            var user = result.FirstOrDefault();

            // Generate token
            if(user!=null)
            {
                var jwtToken = _ITokenService.GenerateToken(user);
                return jwtToken;
            }else throw new ArgumentNullException("Wrong email or password");
        }

        public async Task<User?> GetUserById(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(user=>user.UserId ==id);
        }

    }
}