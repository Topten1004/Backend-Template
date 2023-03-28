using Application.Commands.Users.CreateUser;
using Application.Commands.Users.DeleteUser;
using Application.Commands.Users.UpdateUser;
using Application.Interfaces;
using Application.Queries;
using Application.Queries.Users.GetAllUsers;
using Application.Queries.Users.GetUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("GetUsers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> GetUsers()
        {
            var query = new GetAllUsersQuery();
            var result = await _mediator.Send(query);

            return Ok(result);
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

        [HttpPost("CreateUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> CreateUser(CreateUserCommand model)
        {
            var result = await _mediator.Send(model);

            return BadRequest(result);
        }

        #endregion

        #region Update User

        /// <summary>
        /// Get All Users
        /// </summary>
        /// <returns>Get list of all Users</returns>
        /// <response code="200"></response>
        /// <response code="400">Not found</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="501">Internel server error</response>

        [HttpPut("UpdateUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutAsync(UpdateUserCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(command);
        }

        #endregion

        #region Delete User

        [HttpDelete("DeleteUser/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAsync(DeleteUserCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(command);
        }

        #endregion
    }
}
