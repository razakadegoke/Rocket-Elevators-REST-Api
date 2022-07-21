using Microsoft.EntityFrameworkCore;
using Rockets_Elevators_web_api;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("mySqlDataBase");
builder.Services.AddDbContext<rocket_peterpanContext>(options => {
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

var app = builder.Build();

if (builder.Environment.IsProduction())
{
    app.UsePathBase("https://rocketelevators-api.azurewebsites.net/swagger/index.html"); 
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
