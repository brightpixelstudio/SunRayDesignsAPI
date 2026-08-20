using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using SunRayDesignsAPI.Data;
using SunRayDesignsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace SunRayDesignsAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")] // Adds the method name to the URL path
    public class SunrayBlogController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILogger<SunrayWorkController> _logger;

        public SunrayBlogController(ILogger<SunrayWorkController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet(Name = "GetAllBlogPosts")]
        public async Task<ActionResult<IEnumerable<GetAllBlogPosts>>> GetAllBlogPosts()
        {
            // MySQL utilizes the 'CALL' syntax
            var getallblogpostsitems = await _context.GetAllBlogPosts
                .FromSqlRaw("CALL GetAllBlogPosts()")
                .ToListAsync();

            if (getallblogpostsitems.Count == 0)
                return NotFound();

            // return results
            return Ok(getallblogpostsitems);
        }

        [HttpGet(Name = "GetAllPostsCountByYear")]
        public async Task<ActionResult<IEnumerable<GetAllPostsCountByYear>>> GetAllPostsCountByYear(int yearparam)
        {
            // Define the parameter to prevent SQL Injection
            var yearParam = new MySqlParameter("@yearparam", yearparam);

            // MySQL utilizes the 'CALL' syntax
            var getallpostscountbyyear = await _context.GetAllPostsCountByYear
                .FromSqlRaw("CALL GetAllPostsCountByYear({0})", yearParam)
                .ToListAsync();

            if (getallpostscountbyyear.Count == 0)
                return NotFound();

            // return results
            return Ok(getallpostscountbyyear);
        }

        [HttpGet(Name = "GetBlogPostsBasedOnTypeAndYear")]
        public async Task<ActionResult<IEnumerable<GetBlogPostsBasedOnTypeAndYear>>> GetBlogPostsBasedOnTypeAndYear(int? typeparam, int yearparam)
        {
            // Define the parameter to prevent SQL Injection
            var typeParamIn = new MySqlParameter("@typeparam", typeparam);
            var yearParamIn = new MySqlParameter("@yearparam", yearparam);

            // MySQL utilizes the 'CALL' syntax
            var getblogpostsbasedontypeandyearitems = await _context.GetBlogPostsBasedOnTypeAndYear
                .FromSqlRaw("CALL GetBlogPostsBasedOnTypeAndYear({0}, {1})", typeParamIn, yearParamIn)
                .ToListAsync();

            if (getblogpostsbasedontypeandyearitems.Count == 0)
                return NotFound();

            // return results
            return Ok(getblogpostsbasedontypeandyearitems);
        }

    }
}
