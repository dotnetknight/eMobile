using System.Threading.Tasks;
using CQRS.Interfaces;
using eMobile.API.Commands;
using eMobile.API.Queries;
using eMobile.Models.Models;
using eMobile.Models.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eMobile.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ICommandBusAsync _commandBus;
        private readonly IQueryBusAsync _queryBus;

        public UsersController(ICommandBusAsync commandBus, IQueryBusAsync queryBus)
        {
            _commandBus = commandBus;
            _queryBus = queryBus;
        }

        /// <summary>
        /// Creates new user in the system
        /// </summary>
        /// <param name="command"></param>
        /// <response code="201">Creates new user in the system</response>
        /// <response code="400">Unable to add new user in the system due to validation error</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        public async Task<ActionResult> Users([FromBody] AddUserCommand command)
        {
            await _commandBus.ExecuteAsync(command);
            return Created("User created", null);
        }

        /// <summary>
        /// Returns list of all orders made by the authenticated user
        /// </summary>
        /// <response code="200">Returns list of all orders made by the authenticated user</response>
        /// <response code="204">Indicates that there's not orders made by the user</response>
        /// <response code="401">User must be authorized</response>
        [Authorize]
        [HttpGet("User/")]
        [ProducesResponseType(typeof(MyOrdersResponse), 200)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Orders()
        {
            var result = await _queryBus.ExecuteAsync<MyOrdersQuery, MyOrdersResponse>(new MyOrdersQuery());
            return Ok(result);
        }
    }
}