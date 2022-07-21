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
        public async Task<IEnumerable<Elevator>> GetElevators() => _context.Elevators.Where(e => e.Status == "notInOperation");

        [HttpGet("{id}")]
        public async Task<IActionResult> GetElevatorStatusById(long id){
            var elevator = _context.Elevators.Where(e => e.Id == id).Select(e => new ElevatorStatus(){Status = e.Status});
            return elevator == null ? NotFound() : Ok(elevator);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateElevatorStatusById(long id, String status){
            var elevator = _context.Elevators.FirstOrDefault(e => e.Id == id);
            if (elevator == null) return NotFound();
            elevator.Status = status;
            await _context.SaveChangesAsync();
            return Ok(elevator);
        }
    }
}