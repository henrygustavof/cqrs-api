using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Project.API.Helpers;
using Project.Application.Consumes.Dto;
using Project.Application.Consumes.Queries.GetConsumes;
using Project.Domain.Constants;

namespace Project.API.Controllers
{

    [ApiController]
    [Authorize]
    [Route("api/consumes")]
    public class ConsumeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ConsumeController> _logger;
        private readonly IMapper _mapper;

        public ConsumeController(ILogger<ConsumeController> logger, IMediator mediator, IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("")]
        [Authorize(Roles = RoleConstants.Admin)]
        [ProducesResponseType(typeof(List<ConsumeDto>), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll()
        {
            var consumes = await _mediator.Send(new GetConsumesQuery());

            return Ok(consumes);
        }

        [HttpGet("devices/{deviceId}")]
        [ProducesResponseType(typeof(ConsumeDeviceDetailDto), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllByDevice(Guid deviceId, string startDate, string endDate)
        {

            var consumes = await _mediator.Send(new GetConsumesByDeviceQuery
            {
                DeviceId = deviceId,
                StartDate = startDate,
                EndDate = endDate,
                IsAdmin = User.IsAdmin(),
                LoggedUserName = User.GetUserName()
            });

            return Ok(consumes);
        }

        [HttpGet("devices/{deviceId}/monthly")]
        [ProducesResponseType(typeof(List<ConsumeDeviceMonthlyDto>), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllByDeviceMonthly(Guid deviceId)
        {
            var consumes = await _mediator.Send(new GetConsumesByDeviceMonthlyQuery
            {
                DeviceId = deviceId,
                IsAdmin = User.IsAdmin(),
                LoggedUserName = User.GetUserName()
            });

            return Ok(consumes);
        }

        [HttpGet("zones/{zoneId}/districts")]
        [Authorize(Roles = RoleConstants.Admin)]
        [ProducesResponseType(typeof(List<ConsumeDistrictDto>), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllByZone(Guid zoneId)
        {
            var consumes = await _mediator.Send(new GetConsumesInDistrictsByZoneQuery {ZoneId = zoneId});

            return Ok(consumes);
        }

        [HttpGet("zones/{zoneId}/districts/{districtId}/devices")]
        [Authorize(Roles = RoleConstants.Admin)]
        [ProducesResponseType(typeof(List<ConsumeDeviceDto>), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllByZoneAndDistrict(Guid zoneId, Guid districtId)
        {
            var consumes = await _mediator.Send(new GetConsumesInDevicesByDistrictQuery
            {
                ZoneId = zoneId,
                DistrictId = districtId
            });

            return Ok(consumes);
        }

        [HttpGet("users")]
        [Authorize(Roles = RoleConstants.Admin)]
        [ProducesResponseType(typeof(List<ConsumeUserDto>), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllByUsers(string zoneId, string districtId, string startDate,
            string endDate, string docNumber)
        {
            var consumes = await _mediator.Send(new GetConsumesByUsersQuery
            {
                ZoneId = string.IsNullOrEmpty(zoneId) ? Guid.Empty : Guid.Parse(zoneId),
                DistrictId = string.IsNullOrEmpty(districtId) ? Guid.Empty : Guid.Parse(districtId),
                StartDate = startDate,
                EndDate = endDate,
                DocNumber = docNumber
            });

            return Ok(consumes);
        }
    }
}
