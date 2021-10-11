using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Project.Application.Zones.Dto;
using Project.Application.Zones.Queries.GetDistricts;
using Project.Application.Zones.Queries.GetZones;
using Project.Domain.Constants;

namespace Project.API.Controllers
{
    [ApiController]
    [Authorize(Roles = RoleConstants.Admin)]
    [Route("api/zones")]
    public class ZoneController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ZoneController> _logger;
        private readonly IMapper _mapper;

        public ZoneController(ILogger<ZoneController> logger, IMediator mediator, IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("")]
        [ProducesResponseType(typeof(List<ZoneDto>), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            var zones = await _mediator.Send(new GetZonesQuery());

            return Ok(zones);
        }

        [HttpGet("districts")]
        [ProducesResponseType(typeof(List<DistrictDto>), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> GetDistricts()
        {
            var districts = await _mediator.Send(new GetDistrictsQuery());

            return Ok(districts);
        }
    }
}