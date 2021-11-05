using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;
using Project.Application.Devices.Commands.SaveDevice;
using Project.Application.Devices.Dto;
using Project.Application.Devices.Queries.GetDevice;
using Project.Domain.Constants;

namespace Project.API.Controllers
{


    [ApiController]
    [Authorize(Roles = RoleConstants.Admin)]
    [Route("api/devices")]
    public class DeviceController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<DeviceController> _logger;
        private readonly IMapper _mapper;

        public DeviceController(ILogger<DeviceController> logger, IMediator mediator, IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }

        [Route("{id}")]
        [HttpGet]
        [ProducesResponseType(typeof(DeviceDto), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> Get(Guid id)
        {
            var device = await _mediator.Send(new GetDeviceQuery(id));

            return Ok(device);
        }

        /// <summary>
        /// Save
        /// </summary>
        [Route("")]
        [HttpPost]
        public async Task<IActionResult> Save([FromBody] SaveDeviceRequest request)
        {
            var saveDeviceCommand = _mapper.Map<SaveDeviceCommand>(request);
            var response = await _mediator.Send(saveDeviceCommand);

            return Created(string.Empty, response);
        }
    }
}