using GameLogic;
using Microsoft.AspNetCore.SignalR;

namespace API
{
    public class PlayerHub : Hub
    {
        public void UpdateModel(Player player)
        {
            player.Identity = Context.ConnectionId;
            // Update the shape model within our broadcaster
            Clients.AllExcept(player.Identity).SendAsync("UpdatePlayer", player);
        }
    }
}