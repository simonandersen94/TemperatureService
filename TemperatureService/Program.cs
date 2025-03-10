using TemperatureService.BusinessLogic;
using TemperatureService.Config;
using TemperatureService.Data;

var builder = WebApplication.CreateBuilder(args);

var config = Config.LoadConfig();
builder.Services.AddSingleton(config);


builder.Services.AddTransient<TemperatureAccess>();
builder.Services.AddTransient<TemperatureControl>();

builder.Services.AddControllers();

var app = builder.Build();

app.UseRouting();

app.MapControllers();

app.Run();
