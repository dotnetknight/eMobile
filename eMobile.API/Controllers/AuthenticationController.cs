using eMobile.API.Requests;
using eMobile.API.Services;
using eMobile.Models.Models;
using eMobile.Models.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eMobile.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly TokenService _tokenService;

        public AuthenticationController(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        /// <summary>
        /// Authorizes user in the system and returns authentication  token
        /// </summary>
        /// <response code="200">Authorizes user in the system and returns authentication token</response>
        /// <response code="400">Unable to log the user in due to validation error</response>
        /// <response code="401">Incorrect credentials provided</response>
        /// <response code="404">User not found</response>
        [HttpPost]
        [ProducesResponseType(typeof(TokenResponse), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ExceptionModel), 404)]
        public IActionResult Login([FromBody] AuthenticationRequest request)
        {
            return Ok(
                _tokenService.CreateToken(request.Email, request.Password));
        }
    }
}