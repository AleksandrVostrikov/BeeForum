using BeeForum.Storage.Data;
using BeeForum.Storage.Models;
using Microsoft.AspNetCore.Mvc;

namespace BeeForum.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ForumController : ControllerBase
    {
        private readonly BeeForumDbContext _beeForumDbContext;

        public ForumController(BeeForumDbContext beeForumDbContext)
        {
            _beeForumDbContext = beeForumDbContext;
        }
        
        [HttpGet]
        public async Task<IQueryable<Forum>> GetForumAsync()
        {
            return await Task.FromResult(_beeForumDbContext.Forums);
        }
        
    }
}