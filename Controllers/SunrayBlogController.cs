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
                return NotFound(new { Message = "Get All Blog Posts Not Found" });

            // return results
            return Ok(getallblogpostsitems);
        }

        [HttpGet(Name = "GetAllPostsCountByYearByMonth")]
        public async Task<ActionResult<IEnumerable<GetAllPostsCountByYearByMonth>>> GetAllPostsCountByYearByMonth(int yearparam)
        {
            // Define the parameter to prevent SQL Injection
            var yearParam = new MySqlParameter("@yearparam", yearparam);

            // MySQL utilizes the 'CALL' syntax
            var getallpostscountbyyearbymonth = await _context.GetAllPostsCountByYearByMonth
                .FromSqlRaw("CALL GetAllPostsCountByYearByMonth({0})", yearParam)
                .ToListAsync();

            if (getallpostscountbyyearbymonth.Count == 0)
                return NotFound(new { Message = "Get All Posts Count By Year Not Found" });

            // return results
            return Ok(getallpostscountbyyearbymonth);
        }

        [HttpGet(Name = "GetBlogPostsBasedOnTypeAndYear")]
        public async Task<ActionResult<IEnumerable<GetBlogPostsBasedOnTypeAndYear>>> GetBlogPostsBasedOnTypeAndYear(int yearparam, int? typeparam, int? monthparam)
        {
            // Define the parameter to prevent SQL Injection
            var yearParamIn = new MySqlParameter("@yearparam", yearparam);
            var typeParamIn = new MySqlParameter("@typeparam", typeparam);
            var monthParamIn = new MySqlParameter("@monthparam", monthparam);

            // MySQL utilizes the 'CALL' syntax
            var getblogpostsbasedontypeandyearitems = await _context.GetBlogPostsBasedOnTypeAndYear
                .FromSqlRaw("CALL GetBlogPostsBasedOnTypeAndYear({0}, {1}, {2})", yearParamIn, typeParamIn, monthParamIn)
                .ToListAsync();

            if (getblogpostsbasedontypeandyearitems.Count == 0)
                return NotFound(new { Message = "Get Blog Posts Based On Type And Year Not Found" });

            // return results
            return Ok(getblogpostsbasedontypeandyearitems);
        }

        [HttpGet(Name = "GetBlogPost")]
        public IActionResult GetBlogPost(string url)
        {
            // Define the parameter to prevent SQL Injection
            var blogpostparam = new MySqlParameter("@url", url);

            // MySQL utilizes the 'CALL' syntax
            var getblogpostitem = _context.GetBlogPost
                .FromSqlRaw("CALL GetBlogPost({0})", blogpostparam);

            if (getblogpostitem == null)
                return NotFound(new { Message = "Post not found" });

            // return results
            return Ok(getblogpostitem);
        }

        [HttpGet(Name = "GetAllBlogPostYears")]
        public IActionResult GetAllBlogPostYears()
        {
            // MySQL utilizes the 'CALL' syntax
            var getblogpostyearsitems = _context.GetAllBlogPostYears
                .FromSqlRaw("CALL GetAllBlogPostYears()");

            if (getblogpostyearsitems == null)
                return NotFound(new { Message = "Blog post years not found" });

            // return results
            return Ok(getblogpostyearsitems);
        }

        [HttpGet(Name = "GetAllBlogTypes")]
        public IActionResult GetAllBlogTypes()
        {
            // MySQL utilizes the 'CALL' syntax
            var getblogtypesitems = _context.GetAllBlogTypes
                .FromSqlRaw("CALL GetAllBlogTypes()");

            if (getblogtypesitems == null)
                return NotFound(new { Message = "Blog post types not found" });

            // return results
            return Ok(getblogtypesitems);
        }

        [HttpGet(Name = "GetLatestBlogPosts")]
        public IActionResult GetLatestBlogPosts()
        {
            // MySQL utilizes the 'CALL' syntax
            var getlatestblogpostsitems = _context.GetLatestBlogPosts
                .FromSqlRaw("CALL GetLatestBlogPosts()");

            if (getlatestblogpostsitems == null)
                return NotFound(new { Message = "Blog latest post not found" });

            // return results
            return Ok(getlatestblogpostsitems);
        }

        [HttpGet(Name = "GetAllPostsCountByYearByCategory")]
        public IActionResult GetAllPostsCountByYearByCategory(int yearparam)
        {
            // Define the parameter to prevent SQL Injection
            var yearparamin = new MySqlParameter("@yearparam", yearparam);

            // MySQL utilizes the 'CALL' syntax
            var getallpostscountbyyearbycategoryitems = _context.GetAllPostsCountByYearByCategory
                .FromSqlRaw("CALL GetAllPostsCountByYearByCategory({0})", yearparamin);

            if (getallpostscountbyyearbycategoryitems == null)
                return NotFound(new { Message = "Blog categories not found" });

            // return results
            return Ok(getallpostscountbyyearbycategoryitems);
        }

    }
}
