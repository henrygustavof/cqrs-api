using System;
using Project.Application.Configuration.Queries;
using Project.Application.Consumes.Dto;

namespace Project.Application.Consumes.Queries.GetConsumes
{
    public class GetConsumesByDeviceQuery : IQuery<ConsumeDeviceDetailDto>
    {
        public Guid DeviceId { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public bool IsAdmin { get; set; }
        public string LoggedUserName { get; set; }

    }
}
