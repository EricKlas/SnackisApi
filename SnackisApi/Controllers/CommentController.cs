using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SnackisApi.Data;
using SnackisApi.Models;
using System.Reflection.Metadata.Ecma335;

namespace SnackisApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly DataContext _context;

        public CommentController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Comment>>> GetAllComments()
        {
           
            var comments = await _context.Comment.ToListAsync();

       
            return Ok(comments);
       }

        [HttpGet("count")]
        public async Task<ActionResult<List<Comment>>> GetCountComments()
        {

            var comments = await _context.Comment.ToListAsync();


            var commentsCount = comments.Count();

            return Ok(commentsCount);
        }
    }
}
