using System.Threading;
using System.Threading.Tasks;
using Project.Domain.Repository;

namespace Project.Infrastructure.Database.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProjectContext _context;

        public UnitOfWork(ProjectContext context)
        {
            _context = context;
            Devices = new DeviceRepository(_context);
            Consumes = new ConsumeRepository(_context);
            Zones = new ZoneRepository(_context);

        }

        public IDeviceRepository Devices { get; }
        public IConsumeRepository Consumes { get; }
        public IZoneRepository Zones { get; }

        public async Task<int> CommitAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
