using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace Chat.Hubs
{
    public class MessageHub : Hub
    {
        public async Task RegisterMessageListening(Guid[] roomIds, Guid userId)
        {
            foreach (var roomId in roomIds)
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, roomId.ToString());
            }

            await Groups.AddToGroupAsync(Context.ConnectionId, userId.ToString());
        }

        public async Task RegisterMessageListeningForRoom(Guid roomId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, roomId.ToString());
        }
    }
}
