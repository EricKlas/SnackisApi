using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
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
        public async Task<ActionResult<List<Post>>> GetAllPosts()
        {
            var post = await _context.Post.Include(p => p.Comments).ToListAsync();
            return Ok(post);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Post>>> GetPost(int id)
        {
            var post = await _context.Post.Include(p => p.Comments).FirstOrDefaultAsync(p => p.Id == id);
            if (post is null)
                return NotFound("Post not found.");
            return Ok(post);
        }
        [HttpGet("random")]
        public async Task<ActionResult<List<Post>>> GetRandomPost()
        {
            var post = await _context.Post.Include(p => p.Comments).ToListAsync();
            if (post == null || post.Count == 0)
                return NotFound("No posts found.");

            var random = new Random();
            int randomIndex = random.Next(post.Count);
            var randomPost = post[randomIndex];

            return Ok(randomPost);
        }
        [HttpGet("count")]
        public async Task<ActionResult<List<Post>>> GetCountAllPost()
        {
            var post = await _context.Post.Include(p => p.Comments).ToListAsync();

            var postCount = post.Count;

            return Ok(postCount);
        }
    }
}
