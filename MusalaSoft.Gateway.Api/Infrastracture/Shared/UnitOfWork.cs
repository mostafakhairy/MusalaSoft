using MusalaSoft.GatewayApp.Api.Core;
using MusalaSoft.GatewayApp.Api.Core.IRepositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusalaSoft.GatewayApp.Api.Infrastracture.Shared
{
    public class UnitOfWork : IUnitOfWork
    {
        public ApplicationDbContext _db { get; set; }
        public UnitOfWork(ApplicationDbContext context)
        {
            _db = context;
        }
        public async Task<int> Complete()
        {
            return await _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
