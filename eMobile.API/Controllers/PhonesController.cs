using CQRS.Interfaces;
using eMobile.API.Commands;
using eMobile.API.Queries;
using eMobile.Models.Models;
using eMobile.Models.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eMobile.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PhonesController : ControllerBase
    {
        private readonly ICommandBusAsync _commandBus;
        private readonly IQueryBusAsync _queryBus;

        public PhonesController(ICommandBusAsync commandBus, IQueryBusAsync queryBus)
        {
            _commandBus = commandBus;
            _queryBus = queryBus;
        }

        #region GetRequests
        /// <summary>
        /// Returns list of all phones in the system
        /// </summary>
        /// <response code="200">Returns list of all phones in the system</response>
        [HttpGet]
        [ProducesResponseType(typeof(PhoneListResponse), 200)]
        public async Task<IActionResult> Phones()
        {
            var result = await _queryBus.ExecuteAsync<PhoneListQuery, PhoneListResponse>(new PhoneListQuery());
            return Ok(result);
        }

        /// <summary>
        /// Returns phone
        /// </summary>
        /// <response code="200">Returns phone</response>
        /// <response code="404">Unable to find phone with provided id</response>
        [HttpGet("{Id}")]
        [ProducesResponseType(typeof(PhoneQueryResponse), 200)]
        [ProducesResponseType(typeof(ExceptionModel), 404)]
        public async Task<IActionResult> Phone([FromRoute] PhoneQuery query)
        {
            var result = await _queryBus.ExecuteAsync<PhoneQuery, PhoneQueryResponse>(query);
            return Ok(result);
        }

        /// <summary>
        /// Looks for phone with criterias provided
        /// </summary>
        /// <response code="200">Looks for phone with criterias provided</response>
        /// <response code="204">No result matches your criteria</response>
        [HttpGet]
        [ProducesResponseType(typeof(FilterQueryResponse), 200)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Filter([FromQuery] FilterQuery query)
        {
            var result = await _queryBus.ExecuteAsync<FilterQuery, FilterQueryResponse>(query);
            return Ok(result);
        }

        /// <summary>
        /// Returns phone's media information: photo and video urls
        /// </summary>
        /// <response code="200">Returns phone's media information: photo and video urls</response>
        /// <response code="404">Unable to find photos and videos for provided id</response>
        [HttpGet("Phone/{Id}")]
        [ProducesResponseType(typeof(PhoneMediaResonse), 200)]
        [ProducesResponseType(typeof(ExceptionModel), 404)]
        public async Task<IActionResult> Media([FromRoute] PhoneMediaQuery query)
        {
            var result = await _queryBus.ExecuteAsync<PhoneMediaQuery, PhoneMediaResonse>(query);
            return Ok(result);
        }
        #endregion

        #region PostRequests
        /// <summary>
        /// Creates new phone in the system
        /// </summary>
        /// <param name="command"></param>
        /// <response code="201">Creates new phone in the system</response>
        /// <response code="400">Unable to add new phone the system due to validation error</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        public async Task<IActionResult> Phone([FromBody] AddPhoneCommand command)
        {
            await _commandBus.ExecuteAsync(command);
            return Created("Phone was created", null);
        }
        #endregion

        #region PutRequests
        /// <summary>
        /// Updates phone details
        /// </summary>
        /// <param name="command"></param>
        /// <param name="Id"></param>
        /// <response code="200">Updates phone details</response>
        /// <response code="400">Unable to update phone due to validation error</response>
        /// <response code="404">Phone wasn't found in the system</response>
        [HttpPut("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        [ProducesResponseType(typeof(ExceptionModel), 404)]
        public async Task<IActionResult> Phone([FromBody] UpdatePhoneCommand command, [FromRoute] int Id)
        {
            await _commandBus.ExecuteAsync(command);
            return Ok();
        }

        /// <summary>
        /// Updates phone photo and video urls
        /// </summary>
        /// <param name="command"></param>
        /// <param name="Id"></param>
        /// <response code="200">Updates phone photo and video urls</response>
        /// <response code="400">Unable to update media due to validation error</response>
        /// <response code="404">Media wasn't found in the system</response>
        [HttpPut("Phone/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        [ProducesResponseType(typeof(ExceptionModel), 404)]
        public async Task<IActionResult> Media([FromBody] UpdateMediaCommand command, [FromRoute] int Id)
        {
            await _commandBus.ExecuteAsync(command);
            return Ok();
        }

        #endregion

        #region DeleteRequests
        /// <summary>
        ///  Deletes phone in the system
        /// </summary>
        /// <param name="Id"></param>
        /// <response code="200">Deletes phone in the system</response>
        /// <response code="404">Unable to delete phone because it's not found in the system</response>
        [HttpDelete("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExceptionModel), 404)]
        public async Task<IActionResult> Phone([FromRoute] int Id)
        {
            await _commandBus.ExecuteAsync(new DeletePhoneCommand());
            return Ok();
        }

        /// <summary>
        ///  Deletes phone photo and video urls
        /// </summary>
        /// <param name="Id"></param>
        /// <response code="200">Deletes phone photo and video urls</response>
        /// <response code="404">Unable to delete media because phone wasn't found in the system</response>
        [HttpDelete("Phone/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExceptionModel), 404)]
        public async Task<IActionResult> Media([FromRoute] int Id)
        {
            await _commandBus.ExecuteAsync(new DeleteMediaCommand());
            return Ok();
        }

        #endregion
    }
}