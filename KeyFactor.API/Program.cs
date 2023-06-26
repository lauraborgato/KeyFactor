using EasyCaching.InMemory;
using KeyFactor.Application;
using KeyFactorTest;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddEasyCaching(options =>
{
    // use memory cache with your own configuration
    options.UseInMemory(config =>
    {
        config.DBConfig = new InMemoryCachingOptions
        {
            // scan time, default value is 60s
            ExpirationScanFrequency = 60,
        };
    }, "cache");
});

builder.Services.AddScoped<IServerInformationService, ServerInformationService>();
builder.Services.AddScoped<IRemoteServerInformationService, RemoteServerInformationService>();


var app = builder.Build();

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
