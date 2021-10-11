using System;
using System.Threading;
using System.Threading.Tasks;

namespace Project.Domain.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IDeviceRepository Devices { get; }
        IConsumeRepository Consumes { get; }

        IZoneRepository Zones { get; }
        Task<int> CommitAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}