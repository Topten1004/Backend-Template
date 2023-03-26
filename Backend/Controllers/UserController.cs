using Application.Commands;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels.Request;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region Get all Users list
        /// <summary>
        /// Get All Users
        /// </summary>
        /// <returns>Get list of all Users</returns>
        /// <response code="200"></response>
        /// <response code="400">Not found</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="501">Internel server error</response>

        [Authorize()]
        [HttpGet("GetUsers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> GetUsers()
        {
            var results = await _mediator.Send(new GetUserListQuery());
            return Ok(results);
        }

        #endregion

        #region Create a User
        /// <summary>
        /// Get All Users
        /// </summary>
        /// <returns>Get list of all Users</returns>
        /// <response code="200"></response>
        /// <response code="400">Not found</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="501">Internel server error</response>

        [Authorize()]
        [HttpPost("CreateUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> CreateUser(CreateUserVM model)
        {    
            return Ok();
        }

        #endregion
    }
}
