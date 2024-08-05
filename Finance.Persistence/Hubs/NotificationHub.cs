using Finance.Domain.Entities.SignalR;
using Finance.Persistence.Context;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
namespace Finance.Persistence.Hubs
{
    public class NotificationHub : Hub
    {
        private readonly FinanceDbContext _context;

        public NotificationHub(FinanceDbContext context)
        {
            _context = context;
        }

        public override async Task OnConnectedAsync()
        {
            var userId = Context.UserIdentifier; // Kullanıcı ID'si
            var connectionId = Context.ConnectionId;

            var userConnection = new UserConnection
            {
                UserId = userId,
                ConnectionId = connectionId
            };

            _context.UserConnections.Add(userConnection);
            await _context.SaveChangesAsync();

            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var connectionId = Context.ConnectionId;

            var userConnection = await _context.UserConnections
                                                 .FirstOrDefaultAsync(c => c.ConnectionId == connectionId);
            if (userConnection != null)
            {
                _context.UserConnections.Remove(userConnection);
                await _context.SaveChangesAsync();
            }

            await base.OnDisconnectedAsync(exception);
        }
    }
}
