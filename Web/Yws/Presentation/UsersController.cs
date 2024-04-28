using Contracts.User;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace Presentation
{
    [ApiController]
    [Route("users")]
    public class UsersController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public UsersController(IServiceManager serviceManager) => _serviceManager = serviceManager;

        [HttpGet]
        public async Task<IActionResult> GetUsers(CancellationToken cancellationToken)
        {
            var owners = await _serviceManager.UserService.GetAllAsync(cancellationToken);

            return Ok(owners);
        }

        [HttpGet("{userId:guid}")]
        public async Task<IActionResult> GetUserById(Guid userId, CancellationToken cancellationToken)
        {
            var ownerDto = await _serviceManager.UserService.GetByIdAsync(userId, cancellationToken);

            return Ok(ownerDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserForCreationDto userForCreationDto)
        {
            var userDto = await _serviceManager.UserService.CreateAsync(userForCreationDto);

            return CreatedAtAction(nameof(GetUserById), new { ownerId = userDto.Id }, userDto);
        }

        [HttpPut("{userId:guid}")]
        public async Task<IActionResult> UpdateUser(Guid userId, [FromBody] UserForUpdateDto userForUpdateDto, CancellationToken cancellationToken)
        {
            await _serviceManager.UserService.UpdateAsync(userId, userForUpdateDto, cancellationToken);

            return NoContent();
        }

        [HttpDelete("{userId:guid}")]
        public async Task<IActionResult> DeleteUser(Guid userId, CancellationToken cancellationToken)
        {
            await _serviceManager.UserService.DeleteAsync(userId, cancellationToken);

            return NoContent();
        }
    }
}
