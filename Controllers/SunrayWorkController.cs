using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using SunRayDesignsAPI.Data;
using SunRayDesignsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace SunRayDesignsAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")] // Adds the method name to the URL path
    public class SunrayWorkController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILogger<SunrayWorkController> _logger;

        public SunrayWorkController(ILogger<SunrayWorkController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet(Name = "Work")]
        public async Task<ActionResult<IEnumerable<Work>>> GetWorkByType(int worktypeid)
        {
            // Define the parameter to prevent SQL Injection
            var worktypeidParam = new MySqlParameter("@worktypeid", worktypeid);

            // MySQL utilizes the 'CALL' syntax
            var getworkitems = await _context.Work
                .FromSqlRaw("CALL GetWork({0})", worktypeidParam)
                .ToListAsync();

            if (getworkitems.Count == 0)
                return NotFound();

            // return results
            return Ok(getworkitems);
        }

        [HttpGet(Name = "Technology")]
        public async Task<ActionResult<IEnumerable<Technology>>> GetTechnologyByType(int technologytypeid)
        {
            // Define the parameter to prevent SQL Injection
            var technologytypeidParam = new MySqlParameter("@technologytypeid", technologytypeid);

            // MySQL utilizes the 'CALL' syntax
            var gettechnologyitems = await _context.Technology
                .FromSqlRaw("CALL GetTechnology({0})", technologytypeidParam)
                .ToListAsync();

            if (gettechnologyitems.Count == 0)
                return NotFound();

            // return results
            return Ok(gettechnologyitems);
        }

        [HttpGet(Name = "Quote")]
        public async Task<ActionResult<IEnumerable<Quote>>> GetQuotes()
        {
            // MySQL utilizes the 'CALL' syntax
            var getquoteitems = await _context.Quote
                .FromSqlRaw("CALL GetQuote()")
                .ToListAsync();

            if (getquoteitems.Count == 0)
                return NotFound();

            // return results
            return Ok(getquoteitems);
        }

        [HttpGet(Name = "Industry")]
        public async Task<ActionResult<IEnumerable<Industry>>> GetIndustries()
        {
            // MySQL utilizes the 'CALL' syntax
            var getindustryitems = await _context.Industry
                .FromSqlRaw("CALL GetIndustry()")
                .ToListAsync();

            if (getindustryitems.Count == 0)
                return NotFound();

            // return results
            return Ok(getindustryitems);
        }

    }
}
