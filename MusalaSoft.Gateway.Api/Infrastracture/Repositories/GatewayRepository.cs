using MusalaSoft.GatewayApp.Api.Core.IRepositories;
using MusalaSoft.GatewayApp.Api.Core.Models;
using MusalaSoft.GatewayApp.Api.Infrastracture.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusalaSoft.GatewayApp.Api.Infrastracture.Repositories
{
    public class GatewayRepository : Repository<Gateway>, IGatewayRepository
    {
        public GatewayRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
