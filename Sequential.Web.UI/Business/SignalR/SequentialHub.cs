using Appointment.Common.Entities.Dtos.RequestNumber;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;

namespace Sequential.Web.UI.Business.SignalR
{
    public class SequentialHub : Hub
    {
        HttpContextAccessor _httpContextAccessor;
        private string _channelName;

        public SequentialHub(HttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;

        }
        public override Task OnConnectedAsync()
        {
            System.Console.WriteLine("Yeni bir bağlantı: " + Context.ConnectionId);
            _channelName = Context.ConnectionId;
            Clients.Client(Context.ConnectionId).SendAsync("YeniBaglanti", "Yeni bir giriş algılandı.", Context.ConnectionId);
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            System.Console.WriteLine("Kapatılan bağlantı: " + Context.ConnectionId);
            Clients.Client(Context.ConnectionId).SendAsync("KapatilanBaglanti", "Bağlantı kapatıldı.", Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }

        // Group Join
        public Task JoinDirectorate(string group)
        {
            return Groups.AddToGroupAsync(Context.ConnectionId, group);
        }

        public async Task RequestNumber(string sender, string message)
        {
            var request = JsonConvert.DeserializeObject<RequestNumber>(message);
            await Clients.Group(sender).SendAsync("requestNumber", sender, message);

        }
    }
}
