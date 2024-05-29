using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SnackisApi.Data;
using SnackisApi.Models;

namespace SnackisApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly DataContext _context;

        public PostController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Post>>> GeAllPosts()
        {
            var post = await _context.Post.ToListAsync();
            return Ok(post);
        }
    }
}
