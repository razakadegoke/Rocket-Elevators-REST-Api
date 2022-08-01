using Microsoft.AspNetCore.Mvc;
using Rockets_Elevators_web_api;
using Microsoft.EntityFrameworkCore;

namespace Rockets_Elevators_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterventionController : ControllerBase
    {
        private readonly rocket_peterpanContext _context;

        public InterventionController(rocket_peterpanContext context) => _context = context;
        
        [HttpGet]
        public async Task<IActionResult> GetInterventionBystatus()
        {
            var intervention =  _context.Interventions.Where(i => i.status == "Pending" && (i.interventionDateStart == null ||i.interventionDateStart == ""));
            if (intervention == null) return NotFound();
            return Ok(intervention);
        }

        [HttpPut("Starting New Intervention {id}/{interventionDateStart}")]
        public async Task<IActionResult> ChangeStatusAndStartDate(long id,string interventionDateStart)
        {
            var intervention = _context.Interventions.Find(id);
            if (intervention == null) return NotFound();
            intervention.status = "InProgress";
            intervention.interventionDateStart = interventionDateStart;
            await _context.SaveChangesAsync();
            return Ok(intervention);

        }

        [HttpPut("Ending New Intervention {id}/end/{interventionDateEnd}")]
        public async Task<IActionResult> ChangeStatusAndEndDate(long id,string interventionDateEnd)
        {
            var intervention = _context.Interventions.Find(id);
            if (intervention == null) return NotFound();
            intervention.status = "Completed";
            intervention.interventionDateEnd = interventionDateEnd;
            await _context.SaveChangesAsync();
            return Ok(intervention);
        }

    }
}