using Microsoft.AspNetCore.Mvc;
using TrialsSystem.UsersService.Infrastructure.Models.UserDTOs;
using MediatR;
using TrialsSystem.UsersService.Api.Application.Commands.UsersCommands;
using TrialsSystem.UsersService.Api.Application.Queries.UsersQueries;
using TrialsSystem.UsersService.Infrastructure.Repositories.QueryParameters;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace TrialsSystem.UsersService.Api.Controllers.v1
{
    /// <summary>
    /// User management controller
    /// </summary>
    [Route("api/v1/{userId}/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get all users by setting parameters and filters
        /// </summary>
        /// <param name="userId">authorized user Id</param>
        /// <param name="email">part of email (filter)</param>
        /// <param name="pg">pagination parameters</param>
        /// <returns>List of all users</returns>
        /// <response code="200">Success</response>
        /// <response code="400">No users are found</response>
        /// <response code="500">Something is wrong on a server</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetUsersResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> GetAsync(
            [FromRoute] string userId,
            [FromQuery] string? email = null,
            [FromQuery] Pagination? pg = null)
        {
            var response = await _mediator.Send(new UsersQuery(pg, email));
            return Ok(response);
        }

        /// <summary>
        /// Get single user by its id
        /// </summary>
        /// <param name="userId">authorized user id</param>
        /// <param name="id">requested user id</param>
        /// <returns></returns>
        /// <response code="200">Success</response>
        /// <response code="400">User is not found</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetUserResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAsync(
            [FromRoute] string userId,
            [FromRoute] string id)
        {
            var response = await _mediator.Send(new UserQuery(id));

            return Ok(response);
        }

        /// <summary>
        /// Post new single user made of request parameters 
        /// </summary>
        /// <param name="userId">authorized user Id</param>
        /// <param name="request">request body</param>
        /// <returns>Newly created user instance</returns>
        /// <response code="200">User added successfully</response>
        /// <response code="400">User with given email already exists</response>
        [HttpPost]
        [ProducesResponseType(typeof(CreateUserResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostAsync(
            [FromRoute] string userId,
            [FromBody] CreateUserRequest request)
        {
            var response = await _mediator.Send(new CreateUserCommand(request.Email,
                                                                             request.Name,
                                                                             request.Surname,
                                                                             request.CityId,
                                                                             request.BirthDate,
                                                                             request.Weight,
                                                                             request.Height,
                                                                             request.GenderId,
                                                                             userId));
            return Ok(response);

        }

        /// <summary>
        /// Update single user by its id with provided request parameters
        /// </summary>
        /// <param name="userId">authorized user Id</param>
        /// <param name="id">id of user to be updated</param>
        /// <param name="request">request body</param>
        /// <returns>Updated user instance</returns>
        /// <response code="200">User info updated successfully</response>
        /// <response code="400">User is not found</response>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(UpdateUserResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutAsync(
            [FromRoute] string userId, 
            [FromRoute] string id,
            [FromBody] UpdateUserRequest request)
        {
            var response = await _mediator.Send(new UpdateUserCommand(
                                                id,
                                                request.Name,
                                                request.Surname,
                                                request.BirthDate,
                                                request.Weight,
                                                request.Height,
                                                request.CityId,
                                                request.GenderId,
                                                request.DeviceIds,
                                                userId));

            return Ok(response);
        }

        /// <summary>
        /// Deleting user by its id
        /// </summary>
        /// <param name="userId">authorized user Id</param>
        /// <param name="id">id of user to be deleted</param>
        /// <returns></returns>
        /// <response code="200">User removed successfully</response>
        /// <response code="400">User is not found</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteAsync(
            [FromRoute] string userId,
            [FromRoute] string id)
        {
            await _mediator.Send(new DeleteUserCommand(id, userId));
            return Ok();
        }
    }
}
