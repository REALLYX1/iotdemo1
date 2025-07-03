using IotApiDemo1.Domain.Data;
using IotApiDemo1.Domain.Repositories;
using IotApiDemo1.Domain.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add Mongo settings
builder.Services.Configure<DatabaseSetting>(
    builder.Configuration.GetSection("DatabaseSetting"));

// Register repository
builder.Services.AddScoped<IDeviceRepository, DeviceRepository>();
builder.Services.AddScoped<IFactoryRepository, FactoryRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();
