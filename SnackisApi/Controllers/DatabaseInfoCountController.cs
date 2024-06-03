using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SnackisApi.DAL;
using SnackisApi.Models;

namespace SnackisApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatabaseInfoCountController : ControllerBase
    {
        private readonly IDatabaseInfoService _databaseInfoService;

        public DatabaseInfoCountController(IDatabaseInfoService databaseInfoService)
        {
            _databaseInfoService = databaseInfoService;
        }

        [HttpGet]
        public async Task<ActionResult<DatabaseInfo>> GetAllcount()
        {
            var databaseinfo = await _databaseInfoService.GetDbInfoCount();
            return Ok(databaseinfo);
        }
    }
}
