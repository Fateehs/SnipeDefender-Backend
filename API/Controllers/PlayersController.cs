using Application.Abstractions.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayersController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlayer([FromBody] Player player)
        {
            try
            {
                await _playerService.CreatePlayer(player);
                return Ok("Player successfully created");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePlayer([FromBody] Player player)
        {
            try
            {
                await _playerService.UpdateUser(player);
                return Ok("Player successfully updated");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer(int id)
        {
            try
            {
                var playerToDelete = await _playerService.GetPlayerById(id);
                await _playerService.DeleteUser(playerToDelete);
                return Ok("Player successfully deleted");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetPlayers()
        {
            try
            {
                var players = await _playerService.GetPlayers();
                return Ok(players);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{playerId}")]
        public async Task<ActionResult<Player>> GetPlayerById(int playerId)
        {
            try
            {
                var player = await _playerService.GetPlayerById(playerId);
                if (player == null)
                {
                    return NotFound();
                }
                return Ok(player); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
