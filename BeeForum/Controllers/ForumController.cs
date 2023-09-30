using BeeForum.Domain.UseCases.GetForum;
using BeeForum.Models;
using Microsoft.AspNetCore.Mvc;

namespace BeeForum.Controllers
{
    [ApiController]
    [Route("forums")]
    public class ForumController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Forum[]))]
        public async Task<IActionResult> GetForumAsync(
            [FromServices] IGetForumsUseCase useCase, CancellationToken cancellationToken)
        {
            var forums = await useCase.ExecuteAsync(cancellationToken);
            return Ok(forums.Select(f => new Forum
            {
                Id = f.Id,
                Title = f.Title
            }));
        }
        
    }
}