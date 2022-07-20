using Microsoft.AspNetCore.Mvc;
using Rockets_Elevators_web_api;
using Microsoft.EntityFrameworkCore;

namespace Rockets_Elevators_web_api.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class ColumnController : ControllerBase{
        private readonly rocket_peterpanContext _context;

        public ColumnController(rocket_peterpanContext context) => _context = context;

        // [HttpGet]
        // public async Task<IEnumerable<Column>> GetColumns() => await _context.Columns.ToListAsync();
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetColumnStatusById(long id){
            var column = _context.Columns.Where(c => c.Id == id).Select(c => new ColumnStatus(){Status = c.Status});
            return column == null ? NotFound() : Ok(column);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateColumnById(long id, Column column){
            if(id != column.Id) return BadRequest();
            _context.Entry(column).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}