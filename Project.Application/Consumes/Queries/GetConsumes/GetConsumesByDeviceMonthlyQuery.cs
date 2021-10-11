using System;
using System.Collections.Generic;
using Project.Application.Configuration.Queries;
using Project.Application.Consumes.Dto;

namespace Project.Application.Consumes.Queries.GetConsumes
{
    public class GetConsumesByDeviceMonthlyQuery : IQuery<List<ConsumeDeviceMonthlyDto>>
    {
        public Guid DeviceId { get; set; }
        public bool IsAdmin { get; set; }
        public string LoggedUserName { get; set; }
    }
}
