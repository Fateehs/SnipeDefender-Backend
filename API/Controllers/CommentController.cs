using Application.Abstractions.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(int userId, int playerId, string text, int reputation)
        {
            try
            {
                await _commentService.AddCommentAsync(userId, playerId, text, reputation);
                return Ok("Comment added successfully.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while adding the comment.");
            }
        }

        [HttpDelete("{commentId}")]
        public async Task<IActionResult> RemoveComment(int commentId)
        {
            try
            {
                await _commentService.RemoveCommentAsync(commentId);
                return Ok("Comment removed successfully.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while removing the comment.");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllComments()
        {
            try
            {
                var comments = await _commentService.GetAllCommentsAsync();
                return Ok(comments);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while retrieving comments.");
            }
        }

        [HttpGet("{playerId}")]
        public async Task<IActionResult> GetCommentsByPlayerId(int playerId)
        {
            try
            {
                var comments = await _commentService.GetCommentsByPlayerIdAsync(playerId);
                return Ok(comments);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while retrieving comments for the player.");
            }
        }
    }
}

