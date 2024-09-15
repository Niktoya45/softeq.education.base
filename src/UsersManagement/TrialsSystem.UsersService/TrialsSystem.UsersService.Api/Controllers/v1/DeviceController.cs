using Microsoft.AspNetCore.Mvc;
using TrialsSystem.UsersService.Infrastructure.Models.DeviceDTOs;
using MediatR;
using TrialsSystem.UsersService.Api.Application.Commands.DeviceCommands;
using TrialsSystem.UsersService.Api.Application.Queries.DeviceQueries;
using TrialsSystem.UsersService.Api.Filters;

namespace TrialsSystem.UsersService.Api.Controllers.v1
{
    [Route("api/v1/{userId}/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DeviceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get all device names
        /// </summary>
        /// <param name="userId">authorized user id</param>
        /// <param name="skip">skip items (pagination parameters)</param>
        /// <param name="take">take items (pagination parameters)</param>
        /// <returns>List of all devices</returns>
        /// <response code="200">Success</response>
        /// <response code="400">No device is found</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetDevicesResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAsync(
            [FromRoute] string userId,
            [FromQuery] int? skip = 0,
            [FromQuery] int? take = null
            )
        {
            var response = await _mediator.Send(new DevicesQuery(take, skip));

            return Ok(response);
        }

        /// <summary>
        /// Get single device by its id
        /// </summary>
        /// <param name="userId">authorized user id</param>
        /// <param name="id">requested device id</param>
        /// <returns></returns>
        /// <response code="200">Success</response>
        /// <response code="400">Device is not found</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetDeviceResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAsync(
            [FromRoute] string userId,
            [FromRoute] string id
            )
        {
            var response = await _mediator.Send(new DeviceQuery(id));

            return Ok(response);
        }

        /// <summary>
        /// Post new single device made of request parameters
        /// </summary>
        /// <param name="request">request body</param>
        /// <returns>Newly created device instance</returns>
        /// <response code="200">Device added successfully</response>
        [HttpPost]
        [ProducesResponseType(typeof(CreateDeviceResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> PostAsync(CreateDeviceRequest request)
        {
            var response = await _mediator.Send(new CreateDeviceCommand(request.SerialNumber,
                request.Model, 
                request.TypeId,
                request.FirmwareVersion));

            return Ok(response);
        }

        /// <summary>
        /// Update single device by its id with provided request parameters
        /// </summary>
        /// <param name="id">id of device to be updated</param>
        /// <param name="request">request body</param>
        /// <returns>Updated device instance</returns>
        /// <response code="200">Device updated successfully</response>
        /// <response code="400">Device is not found</response>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(UpdateDeviceResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutAsync(
            [FromRoute] string id,
            UpdateDeviceRequest request
            )
        {
            var response = await _mediator.Send(new UpdateDeviceCommand(id, 
                request.SerialNumber,
                request.Model,
                request.TypeId,
                request.FirmwareVersion));

            return Ok(response);
        }

        /// <summary>
        /// Delete single device instance by its id
        /// </summary>
        /// <param name="id">id of device to be deleted</param>
        /// <returns></returns>
        /// <response code="200">Device removed successfully</response>
        /// <response code="400">Device is not found</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteAsync([FromRoute] string id)
        {
            await _mediator.Send(new DeleteDeviceCommand(id));

            return Ok();
        }

    }
}