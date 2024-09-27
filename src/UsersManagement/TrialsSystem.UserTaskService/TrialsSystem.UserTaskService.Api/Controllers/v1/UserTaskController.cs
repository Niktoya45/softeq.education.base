using Microsoft.AspNetCore.Mvc;
using TrialsSystem.UserTaskService.Infrastructure.Models.UserTaskDTOs;
using MediatR;
using TrialsSystem.UserTaskService.Api.Application.Commands;
using TrialsSystem.UserTaskService.Api.Application.Queries;

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
        /// Get all task list
        /// </summary>
        /// <param name="userId">authorized user Id</param>
        /// <param name="skip">skip items (pagination parameters)</param>
        /// <param name="take">take items (pagination parameters)</param>
        /// <returns>All task list</returns>
        /// <response code="200">Success</response>
        /// <response code="400">No task was made</response>
        /// <response code="500">Something is wrong on a server</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetUserTaskResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAsync(
            [FromRoute] string userId,
            [FromQuery] int? skip = 0,
            [FromQuery] int? take = null)
        {
            var response = await _mediator.Send(new UserTasksQuery(take, skip));

            return Ok(response);
        }

        /// <summary>
        /// Get task by its id
        /// </summary>
        /// <param name="userId">authorized user Id</param>
        /// <param name="id">requested task id</param>
        /// <returns></returns>
        /// <response code="200">Success</response>
        /// <response code="400">Task is not found</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetUserTaskResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAsync(
            [FromRoute] string userId,
            [FromRoute] string id)
        {
            var response = await _mediator.Send(id);

            return Ok(response);
        }

        /// <summary>
        /// Post new task made of request parameter
        /// </summary>
        /// <param name="request">request body</param>
        /// <returns>Newly created task instance</returns>
        /// <response code="200">Success</response>
        [HttpPost]
        [ProducesResponseType(typeof(CreateUserTaskResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> PostAsync(CreateUserTaskRequest request)
        {
            var response = await _mediator.Send(new CreateUserTaskCommand(request.Name,
                request.Status,
                request.CreatedDateTime,
                request.LastUpdatedDateTime,
                request.AdditionalProperties));

            return Ok(response);
        }

        /// <summary>
        /// Update single task by its id with provided request parameters
        /// </summary>
        /// <param name="id">id of task to be updated</param>
        /// <param name="request">request body</param>
        /// <returns>Updated task instance</returns>
        /// <response code="200">Success</response>
        /// <response code="400">Task is not found</response>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(UpdateUserTaskResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutAsync([FromRoute] string id, UpdateUserTaskRequest request)
        {
            var response = await _mediator.Send(new UpdateUserTaskCommand(id,
                request.Name,
                request.Status,
                request.CreatedDateTime,
                request.LastUpdatedDateTime,
                request.AdditionalProperties));

            return Ok(response);
        }

        /// <summary>
        /// Delete single task by its id
        /// </summary>
        /// <param name="id">id of task to be deleted</param>
        /// <returns></returns>
        /// <response code="200">Success</response>
        /// <response code="400">Task is not found</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteAsync([FromRoute] string id)
        {
            await _mediator.Send(id);

            return Ok();
        }
    }
}