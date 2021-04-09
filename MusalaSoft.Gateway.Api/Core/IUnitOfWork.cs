using MusalaSoft.GatewayApp.Api.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusalaSoft.GatewayApp.Api.Core
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> Complete();

    }
}
