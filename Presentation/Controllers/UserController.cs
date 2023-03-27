using Application.Commands;
using Application.Queries;
using Domain.Commands.User;
using Domain.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ICommandHandler<CreateUserCommand> _createUserCommandHandler;
        private readonly ICommandHandler<UpdateUserCommand> _updateUserCommandHandler;
        private readonly ICommandHandler<DeleteUserCommand> _deleteUserCommandHandler;
        private readonly IUserQueries _userQuries;

        public UserController(ICommandHandler<CreateUserCommand> createUserCommandHandler,
            ICommandHandler<UpdateUserCommand> updateCommandHandler,
            ICommandHandler<DeleteUserCommand> deleteCommandHandler,
            IUserQueries userQuries)
        {
            _createUserCommandHandler = createUserCommandHandler;
            _updateUserCommandHandler = updateCommandHandler;
            _deleteUserCommandHandler = deleteCommandHandler;
            _userQuries = userQuries;
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
            return Ok(_userQuries.GetAllAsync().Result);
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
            var result = await _createUserCommandHandler.HandleAsync(model);

            if (result.Success)
                return Ok(model);

            return BadRequest(result.Errors);
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
            var result = await _updateUserCommandHandler.HandleAsync(command);

            if (result.Success)
                return Ok(command);

            return BadRequest(result.Errors);
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
            var result = await _deleteUserCommandHandler.HandleAsync(command);

            if (result.Success)
                return Ok(command);

            return BadRequest(result.Errors);
        }

        #endregion
    }
}
