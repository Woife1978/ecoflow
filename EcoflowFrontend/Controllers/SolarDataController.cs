using Microsoft.AspNetCore.Mvc;

namespace EcoflowFrontend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SolarDataController : ControllerBase
    {
        private readonly EcoflowPostgreDbContext _dbContext;

        public SolarDataController(EcoflowPostgreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("last")]
        public IActionResult GetLastData([FromQuery] int seconds = 60)
        {
            var since = DateTime.UtcNow.AddSeconds(-seconds);
            var data = _dbContext.solarinputoutputtracker
                .Where(d => d.datetime >= since)
                .OrderBy(d => d.datetime)
                .ToList();
            Console.WriteLine($"Data count: {data.Count}"); // Debugging line to check data count
            return Ok(data);
        }

        [HttpGet("range")]
        public IActionResult GetDataRange([FromQuery] DateTime start, [FromQuery] DateTime end)
        {
            var data = _dbContext.solarinputoutputtracker
                .Where(d => d.datetime >= start && d.datetime <= end)
                .OrderBy(d => d.datetime)
                .ToList();

            return Ok(data);
        }

        [HttpGet("latest-per-device")]
        public IActionResult GetLatestPerDevice([FromQuery] int seconds = 60)
        {
            var devices = _dbContext.ecoflowdevice.ToList();
            var since = DateTime.UtcNow.AddSeconds(-seconds);
            var latestData = devices
                .Select(device => _dbContext.solarinputoutputtracker
                    .Where(d => d.serialnumber == device.Sn)
                    .OrderByDescending(d => d.datetime)
                    .FirstOrDefault())
                .Where(d => d.datetime >= since)
                .OrderBy(d => d.datetime)
                .ToList();

            return Ok(latestData);
        }

        [HttpGet("range-latest-per-device")]
        public IActionResult GetRangeLatestPerDevice([FromQuery] DateTime start, [FromQuery] DateTime end)
        {
            var devices = _dbContext.ecoflowdevice.ToList();
            var latestData = devices
                .Select(device => _dbContext.solarinputoutputtracker
                    .Where(d => d.serialnumber == device.Sn && d.datetime >= start && d.datetime <= end)
                    .OrderByDescending(d => d.datetime)
                    .FirstOrDefault())
                .Where(d => d != null)
                .ToList();

            return Ok(latestData);
        }
    }
}