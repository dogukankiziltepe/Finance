using Finance.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Domain.Entities.SignalR
{
    public class UserConnection:BaseEntity
    {
        public string UserId { get; set; }
        public string ConnectionId { get; set; }
    }
}
