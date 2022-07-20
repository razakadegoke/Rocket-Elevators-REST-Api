using Microsoft.AspNetCore.Mvc;
using Rockets_Elevators_web_api;
using Microsoft.EntityFrameworkCore;

namespace Rockets_Elevators_web_api.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class ElevatorController : ControllerBase{
        private readonly rocket_peterpanContext _context;

        public ElevatorController(rocket_peterpanContext context) => _context = context;

        [HttpGet]
        public async Task<IEnumerable<Elevator>> GetElevators() => _context.Elevators.Where(e => e.Status == "notInOparation");

        [HttpGet("{id}")]
        public async Task<IActionResult> GetElevatorStatusById(long id){
            var elevator = _context.Elevators.Where(e => e.Id == id).Select(e => new ElevatorStatus(){Status = e.Status});
            return elevator == null ? NotFound() : Ok(elevator);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateElevatorById(long id, Elevator elevator){
            if(id != elevator.Id) return BadRequest();
            _context.Entry(elevator).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}