using System;
using Project.Application.Configuration.Queries;
using Project.Application.Devices.Dto;

namespace Project.Application.Devices.Queries.GetDevice
{
    public class GetDeviceQuery : IQuery<DeviceDto>
    {
        public Guid Id { get; }

        public GetDeviceQuery(Guid id)
        {
            Id = id;
        }
    }
}
