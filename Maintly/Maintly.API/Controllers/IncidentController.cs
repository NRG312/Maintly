using Maintly.API.Data;
using Maintly.API.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Maintly.API.Models;

namespace Maintly.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IncidentController: ControllerBase
    {
        private MaintlyContext _context;

        public IncidentController(MaintlyContext context)
        {
            _context = context;
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Incident>> GetID(int id)
        {
            var incident = await _context.Incidents.FirstOrDefaultAsync(mach => mach.Id == id);
            if (incident == null) return NotFound();
            return incident;
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Component>> DeleteByID(int id)
        {
            var incident = await _context.Incidents.FirstOrDefaultAsync(mach => mach.Id == id);
            if (incident == null)
                return NotFound();
            _context.Incidents.Remove(incident);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Component>> UpdateComponent(int id, [FromBody] UpdateComponentDto incident)
        {
            var _incident = await _context.Incidents.FirstOrDefaultAsync(mach => mach.Id == id);
            if (_incident == null)
                return NotFound();
            _incident.Update(incident.Name, incident.ComponentType);
            await _context.SaveChangesAsync();
            return Ok(_incident);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateComponentDto incident)
        {
            if (incident == null)
                return BadRequest();
            var process = GetID(incident.ProcessId);
            if (process == null)
                return NotFound(process);
            //

            var _incident = new Incident(incident.Name, incident.ComponentType, incident.ProcessId);
            _context.Incidents.Add(_incident);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetID), new { id = _incident.Id }, _incident);
        }
    }
}
