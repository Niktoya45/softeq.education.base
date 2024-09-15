using Microsoft.AspNetCore.Mvc;
using TrialsSystem.UsersService.Infrastructure.Models.CityDTOs;
using MediatR;
using TrialsSystem.UsersService.Api.Application.Commands.CityCommands;
using TrialsSystem.UsersService.Api.Application.Queries.CityQueries;
using TrialsSystem.UsersService.Api.Filters;

namespace TrialsSystem.UsersService.Api.Controllers.v1
{
    [Route("api/v1/{userId}/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get all city names
        /// </summary>
        /// <param name="userId">authorized user id</param>
        /// <param name="skip">skip items (pagination parameters)</param>
        /// <param name="take">take items (pagination parameters)</param>
        /// <returns>List of all cities</returns>
        /// <response code="200">Success</response>
        /// <response code="400">No city is found</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetCityResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAsync(
            [FromRoute] string userId,
            [FromQuery] int? skip = 0,
            [FromQuery] int? take = null
            )
        {
            var response = await _mediator.Send(new CitiesQuery(take, skip));

            return Ok(response);
        }

        /// <summary>
        /// Get single city by its id
        /// </summary>
        /// <param name="userId">authorized user id</param>
        /// <param name="id">requested city id</param>
        /// <returns></returns>
        /// <response code="200">Success</response>
        /// <response code="400">City is not found</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetCityResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAsync(
            [FromRoute] string userId,
            [FromRoute] string id
            )
        {
            var response = await _mediator.Send(new CityQuery(id));

            return Ok(response);
        }

        /// <summary>
        /// Post new single city made of request parameters
        /// </summary>
        /// <param name="request">request body</param>
        /// <returns>Newly created city instance</returns>
        /// <response code="200">City added successfully</response>
        [HttpPost]
        [ProducesResponseType(typeof(CreateCityResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> PostAsync(CreateCityRequest request)
        {
            var response = await _mediator.Send(new CreateCityCommand(request.Name));

            return Ok(response);
        }

        /// <summary>
        /// Update single city by its id with provided request parameters
        /// </summary>
        /// <param name="id">id of city to be updated</param>
        /// <param name="request">request body</param>
        /// <returns>Updated city instance</returns>
        /// <response code="200">City updated successfully</response>
        /// <response code="400">City is not found</response>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(UpdateCityResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutAsync(
            [FromRoute] string id,
            UpdateCityRequest request
            ) 
        {
            var response = await _mediator.Send(new UpdateCityCommand(id, request.Name));

            return Ok(response);
        }

        /// <summary>
        /// Delete single city instance by its id
        /// </summary>
        /// <param name="id">id of city to be deleted</param>
        /// <returns></returns>
        /// <response code="200">City removed successfully</response>
        /// <response code="400">City is not found</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteAsync([FromRoute] string id)
        {
            await _mediator.Send(new DeleteCityCommand(id)) ;

            return Ok();
        }


    }
}