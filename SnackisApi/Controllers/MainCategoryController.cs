using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SnackisApi.Data;
using SnackisApi.Models;

namespace SnackisApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainCategoryController : ControllerBase
    {
        private readonly DataContext _context;

        public MainCategoryController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<MainCategory>>> GeAllMainCategories()
        {
            var mainCategory = await _context.MainCategory.ToListAsync();

            return Ok(mainCategory);
        }
    }
}
