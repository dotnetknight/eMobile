using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eMobile.API.Requests;
using eMobile.API.Services;
using eMobile.Models.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eMobile.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TaxAndShippingController : ControllerBase
    {
        private readonly TaxAndShippingCalculationService _taxAndShippingCalculationService;

        public TaxAndShippingController(TaxAndShippingCalculationService taxAndShippingCalculationService)
        {
            _taxAndShippingCalculationService = taxAndShippingCalculationService;
        }

        /// <summary>
        /// Calculates tax and shipping
        /// </summary>
        /// <param name="request"></param>
        /// <response code="200">Calculates tax and shipping</response>
        /// <response code="400">Unable to calculate shipping due to validation error</response>
        [HttpPost]
        [ProducesResponseType(typeof(TaxAndShippingTotalCalculatorResponse), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        public IActionResult Calculate([FromBody] TaxAndShippingCalculationRequest request)
        {
            var result = _taxAndShippingCalculationService.Calculate(request);
            return Ok(result);
        }
    }
}
