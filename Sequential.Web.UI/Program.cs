using Appointment.Common.Business.Abstract.Cache;
using Appointment.Common.Business.Concrete.Cache;
using Sequential.Web.UI.Business;
using Sequential.Web.UI.Business.SignalR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSignalR();
builder.Services.AddSingleton<HttpContextAccessor>();
builder.Services.AddSingleton<SequentialHub>();
builder.Services.AddSingleton<RequestNumberSubscriber>();
builder.Services.AddSingleton<IRedisRequestDirectorateCode6>(sp => new RedisCacheManager(6));
builder.Services.AddSingleton<IRedisAuthorizedUserAccount7>(sp => new RedisCacheManager(7));
builder.Services.AddCors(options => options.AddPolicy("CorsPolicy",
        builder =>
        {
            builder.AllowAnyHeader()
                   .AllowAnyMethod()
                   .SetIsOriginAllowed((host) => true)
                   .AllowCredentials();
        }));

var app = builder.Build();

var RequestNumberSubscriber = app.Services.GetService<RequestNumberSubscriber>();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseCors("CorsPolicy");
app.UseStaticFiles();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<SequentialHub>("/sequentialHub");
    endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Index}/{id?}");
});

app.UseAuthorization();

app.MapRazorPages();

app.Run();
