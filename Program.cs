using System.Text;
using bookingdotcom.Models;
using bookingdotcom.Repository;
using bookingdotcom.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

ConfigServices(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
Configuration(app);







void ConfigServices(WebApplicationBuilder builder)
{
    var services = builder.Services;
    services.AddControllers();
    services.AddDbContext<BookingDbContext>(opt=>
        opt.UseMySQL(builder.Configuration.GetConnectionString("DbContext")??"")
    );
    services.AddScoped<IUserRepository,UserRepository>();
    services.AddScoped<IUserService,UserService>();
    services.AddScoped<ILocationRepository,LocationRepository>();
    services.AddScoped<ILocationService,LocationService>();
    services.AddScoped<IDiscountRepository,DiscountRepository>();
    services.AddScoped<IDiscountService,DiscountService>();
    services.AddScoped<IRatingRepository,RatingRepository>();
    services.AddScoped<IRatingService,RatingService>();
    services.AddScoped<IRoomRepository,RoomRepository>();
    services.AddScoped<IRoomService,RoomService>();
    services.AddScoped<ITokenService,TokenService>();

     // Cấu hình đọc cấu hình từ appsettings.json
    var configuration = builder.Configuration.GetSection("AppSettings");
    var key = Encoding.UTF8.GetBytes(configuration.GetSection("SecretKey").Value??"");

    // Cấu hình xác thực và phân quyền sử dụng JWT
    services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    });

    // Cấu hình phân quyền policy (tùy chọn)
    services.AddAuthorization(options =>
    {
        options.AddPolicy("AdminPolicy", policy => policy.RequireRole("Admin"));
        options.AddPolicy("UserPolicy",policy=>policy.RequireRole("User"));
        // Các policy khác nếu cần
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
}
void Configuration(WebApplication app)
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
