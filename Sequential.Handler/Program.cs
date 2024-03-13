using Appointment.Common.Business.Abstract.Cache;
using Appointment.Common.Business.Concrete.Cache;
using Microsoft.Extensions.Caching.Memory;
using Sequential.Handler.Business;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<HttpClient>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSingleton<IMemoryCache, MemoryCache>();
builder.Services.AddSingleton<IRedisCacheManagerIndexes0>(sp => new RedisCacheManager(0));
builder.Services.AddSingleton<IRedisRequestDirectorateCode6>(sp => new RedisCacheManager(6));
builder.Services.AddSingleton<IRedisAuthorizedUserAccount7>(sp => new RedisCacheManager(7));

builder.Services.AddSingleton<RequestNumberPublish>();
var app = builder.Build();

var RequestNumberPublish = app.Services.GetService<RequestNumberPublish>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
