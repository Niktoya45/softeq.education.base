using Microsoft.AspNetCore.Mvc;
using TrialsSystem.UserTaskService.Infrastructure.Models.UserTaskDTOs;
using MediatR;
using TrialsSystem.UserTaskService.Api.Application.Commands;
using TrialsSystem.UserTaskService.Api.Application.Queries.UserTaskQueries;
using TrialsSystem.UserTaskService.Infrastructure.Repositories.QueryParameters;

namespace TrialsSystem.UserTaskService.Api.Controllers.v1
{
    /// <summary>
    /// UserTask Controller
    /// </summary>
    [Route("api/v1/{userId}/[controller]")]
    [ApiController]
    public class UserTaskController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserTaskController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get all tasks of specific user
        /// </summary>
        /// <param name="userId">authorized user Id</param>
        /// <param name="pg">pagination parameters</param>
        /// <param name="name">task name to be returned (filter)</param>
        /// <returns>All user task list</returns>
        /// <response code="200">Success</response>
        /// <response code="400">No task was found for this user</response>
        /// <response code="500">Something is wrong on a server</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetUserTaskResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetListAsync(
            [FromRoute] string userId,
            [FromQuery] string? name = null,
            [FromQuery] Pagination? pg = null
            )
        {
            var response = await _mediator.Send(new UserTasksQuery(userId,name, pg));

            return Ok(response);
        }

        /// <summary>
        /// Get user task by its id
        /// </summary>
        /// <param name="userId">authorized user Id</param>
        /// <param name="id">requested task id</param>
        /// <returns></returns>
        /// <response code="200">Success</response>
        /// <response code="400">Task is not found</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetUserTaskResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetTaskAsync(
            [FromRoute] string userId,
            [FromQuery] string id)
        {
            var response = await _mediator.Send(new UserTaskQuery(userId, id));

            return Ok(response);
        }

        /// <summary>
        /// Post new task made of request parameter
        /// </summary>
        /// <param name="userId">authorized user Id</param>
        /// <param name="request">request body</param>
        /// <returns>Newly created task instance</returns>
        /// <response code="200">Success</response>
        [HttpPost]
        [ProducesResponseType(typeof(CreateUserTaskResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> PostAsync(
            [FromRoute] string userId,
            [FromBody] CreateUserTaskRequest request
            )
        {
            var response = await _mediator.Send(new CreateUserTaskCommand(request.Name,
                request.UserId,
                request.AdditionalProperties));

            return Ok(response);
        }

        /// <summary>
        /// Update single task with provided request parameters
        /// </summary>
        /// <param name="userId">authorized user Id</param>
        /// <param name="request">request body</param>
        /// <returns>Updated task instance</returns>
        /// <response code="200">Success</response>
        /// <response code="400">Task is not found</response>
        [HttpPut]
        [ProducesResponseType(typeof(UpdateUserTaskResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutAsync(
            [FromRoute] string userId,
            [FromBody] UpdateUserTaskRequest request)
        {
            var response = await _mediator.Send(new UpdateUserTaskCommand(
                request.Name,
                userId,
                request.Status,
                request.AdditionalProperties));

            return Ok(response);
        }

        /// <summary>
        /// Delete single task by its name
        /// </summary>
        /// <param name="userId">authorized user Id</param>
        /// <param name="name">name of task to be deleted</param>
        /// <returns></returns>
        /// <response code="200">Success</response>
        /// <response code="400">Task is not found</response>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteAsync(
            [FromRoute] string userId,
            [FromQuery] string name)
        {
            await _mediator.Send(new DeleteUserTaskCommand(userId, name));

            return Ok();
        }
    }
}