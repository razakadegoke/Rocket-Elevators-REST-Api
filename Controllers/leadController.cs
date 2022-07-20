using Microsoft.AspNetCore.Mvc;
using Rockets_Elevators_web_api;
using Microsoft.EntityFrameworkCore;

namespace Rockets_Elevators_web_api.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadController : ControllerBase{
        private readonly rocket_peterpanContext _context;

        public LeadController(rocket_peterpanContext context) => _context = context;
        
        [HttpGet]
        public async Task<IEnumerable<Lead>> GetLeads() => await _context.Leads.ToListAsync();
    }
}