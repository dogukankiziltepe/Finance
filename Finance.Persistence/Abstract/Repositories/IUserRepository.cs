﻿using Finance.Persistence.Abstract.Generic;
using Finance.Domain.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Persistence.Abstract.Repositories
{
    public interface IUserRepository:IRepository<User>
    {
    }
}
