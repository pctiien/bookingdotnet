var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

ConfigServices(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
Configuration(app);







void ConfigServices(WebApplicationBuilder builder)
{
    var services = builder.Services;
    builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
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
