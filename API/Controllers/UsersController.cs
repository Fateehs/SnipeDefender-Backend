using Application.Abstractions.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            try
            {
                await _userService.CreateUser(user);
                return Ok("User successfully created");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] User user)
        {
            try
            {
                await _userService.UpdateUser(user);
                return Ok("User successfully updated");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var userToDelete = await _userService.GetUserById(id);
                await _userService.DeleteUser(userToDelete);
                return Ok("User successfully deleted");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
