using bookingdotcom.Models;
using bookingdotcom.Repository;
using bookingdotcom.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

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
        opt.UseMySQL(builder.Configuration.GetConnectionString("DbContext"))
    );
    services.AddScoped<IUserRepository,UserRepository>();
    services.AddScoped<IUserService,UserService>();
    services.AddScoped<ILocationRepository,LocationRepository>();
    services.AddScoped<ILocationService,LocationService>();
    services.AddScoped<IDiscountRepository,DiscountRepository>();
    services.AddScoped<IDiscountService,DiscountService>();
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
