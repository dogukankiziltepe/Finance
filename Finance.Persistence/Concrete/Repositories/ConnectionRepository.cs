using Finance.Domain.Entities.SignalR;
using Finance.Persistence.Abstract.Repositories;
using Finance.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Persistence.Concrete.Repositories
{
    public class ConnectionRepository:IConnectionRepository
    {
        private readonly FinanceDbContext _context;

        public ConnectionRepository(FinanceDbContext context)
        {
            _context = context;
        }

        public async Task AddConnectionAsync(string userId, string connectionId)
        {
            var existingConnection = await _context.UserConnections
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (existingConnection != null)
            {
                existingConnection.ConnectionId = connectionId;
                _context.UserConnections.Update(existingConnection);
            }
            else
            {
                var newConnection = new UserConnection { UserId = userId, ConnectionId = connectionId };
                _context.UserConnections.Add(newConnection);
            }

            await _context.SaveChangesAsync();
        }

        public async Task RemoveConnectionAsync(string userId)
        {
            var connection = await _context.UserConnections
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (connection != null)
            {
                _context.UserConnections.Remove(connection);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<string> GetConnectionIdAsync(string userId)
        {
            var connection = await _context.UserConnections
                .FirstOrDefaultAsync(c => c.UserId == userId);

            return connection?.ConnectionId;
        }
    }
}
