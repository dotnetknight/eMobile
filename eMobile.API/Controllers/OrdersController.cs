using System;
using System.Collections.Generic;
using System.Linq;
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
    [Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly ICommandBusAsync _commandBus;
        private readonly IQueryBusAsync _queryBus;

        public OrdersController(ICommandBusAsync commandBus, IQueryBusAsync queryBus)
        {
            _commandBus = commandBus;
            _queryBus = queryBus;
        }

        #region GetRequests
        /// <summary>
        /// Returns list of all orders in the system
        /// </summary>
        /// <response code="200">Returns list of all orders in the system</response>
        /// <response code="204">Indicates that no orders were found in the system</response>
        /// <response code="401">User must be authorized</response>
        [HttpGet]
        [ProducesResponseType(typeof(OrdersListRespone), 200)]
        [ProducesResponseType(typeof(ExceptionModel), 204)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Orders()
        {
            var result = await _queryBus.ExecuteAsync<OrdersListQuery, OrdersListRespone>(new OrdersListQuery());
            return Ok(result);
        }

        ///// <summary>
        ///// Returns list of all orders made by the authenticated user
        ///// </summary>
        ///// <response code="200">Returns list of all orders made by the authenticated user</response>
        ///// <response code="204">Indicates that there's not orders made by the user</response>
        ///// <response code="401">User must be authorized</response>
        //[HttpGet("User/sd")]
        //[ProducesResponseType(typeof(MyOrdersResponse), 200)]
        //[ProducesResponseType(typeof(ExceptionModel), 204)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //public async Task<IActionResult> Orders()
        //{
        //    var result = await _queryBus.ExecuteAsync<MyOrdersQuery, MyOrdersResponse>(new MyOrdersQuery());
        //    return Ok(result);
        //}

        /// <summary>
        /// Returns phone, for specific order
        /// </summary>
        /// <response code="200">Returns phone, for specific order</response>
        /// <response code="404">No order found with provided id</response>
        /// <response code="401">User must be authorized</response>
        [HttpGet("{Id}/Phone")]
        [ProducesResponseType(typeof(OrderPhoneResponse), 200)]
        [ProducesResponseType(typeof(ExceptionModel), 404)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Order([FromRoute] OrderedPhoneQuery query)
        {
            var result = await _queryBus.ExecuteAsync<OrderedPhoneQuery, OrderPhoneResponse>(query);
            return Ok(result);
        }

        #endregion

        #region PostRequests
        /// <summary>
        /// Creates order of the phone
        /// </summary>
        /// <response code="201">Creates order of the phone</response>
        /// <response code="400">Unable to add new phone the system due to validation error</response>
        /// <response code="404">Unable to find phone with specific id</response>
        /// <response code="401">User must be authorized</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        [ProducesResponseType(typeof(ExceptionModel), 404)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Order([FromBody] PhoneOrderCommand command)
        {
            await _commandBus.ExecuteAsync(command);
            return Created("Created order", null);
        }
        #endregion
    }
}