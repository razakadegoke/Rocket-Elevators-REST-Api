using Microsoft.AspNetCore.Mvc;
using Rockets_Elevators_web_api;
using Microsoft.EntityFrameworkCore;

namespace Rockets_Elevators_web_api.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class BatteryController : ControllerBase{
        private readonly rocket_peterpanContext _context;

        public BatteryController(rocket_peterpanContext context) => _context = context;

        // [HttpGet]
        // public async Task<IEnumerable<Battery>> GetBatteries() => await _context.Batteries.ToListAsync();

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBatterieStatusById(long id){
            var battery = _context.Batteries.Where(b => b.Id == id).Select(b => new BatteryStatus(){Status = b.Status});
            return battery == null ? NotFound() : Ok(battery);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBatteryStatusById(long id, Battery battery){
            if(id != battery.Id) return BadRequest();
            _context.Entry(battery).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}