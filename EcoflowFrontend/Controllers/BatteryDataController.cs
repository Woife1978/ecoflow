using Microsoft.AspNetCore.Mvc;

namespace EcoflowFrontend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BatteryDataController : ControllerBase
    {
        private readonly EcoflowPostgreDbContext _dbContext;

        public BatteryDataController(EcoflowPostgreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("last")]
        public IActionResult GetLastData([FromQuery] int seconds = 60)
        {
            var since = DateTime.UtcNow.AddSeconds(-seconds);
            var data = _dbContext.batterysocvoltagetracker
                .Where(d => d.datetime >= since)
                .OrderBy(d => d.datetime)
                .ToList();

            return Ok(data);
        }

        [HttpGet("range")]
        public IActionResult GetDataRange([FromQuery] DateTime start, [FromQuery] DateTime end)
        {
            var data = _dbContext.batterysocvoltagetracker
                .Where(d => d.datetime >= start && d.datetime <= end)
                .OrderBy(d => d.datetime)
                .ToList();

            return Ok(data);
        }
    }
}