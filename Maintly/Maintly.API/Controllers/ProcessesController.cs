using Maintly.API.Data;
using Maintly.API.DTOs;
using Maintly.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Maintly.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProcessesController: ControllerBase
    {
        private readonly MaintlyContext _context;
        public ProcessesController(MaintlyContext context)
        {
            _context = context;
        }
        [HttpGet(Name = "GetProcesses")]
        public async Task<ActionResult<IEnumerable<Process>>> Get() //dzieki Ienumerable moge zrobic metode co na dole dzieki niemu mozna przeiterowac jakies listy itp
        {
            return await _context.Processes.ToListAsync();
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Process>> GetID(int id)
        {
            var process = await _context.Processes.Include(c => c.Components).FirstOrDefaultAsync(p => p.Id == id);
            if (process == null) return NotFound();
            return process;
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Process>> DeleteByID(int id)
        {
            var process = await _context.Processes.Include(c => c.Components).FirstOrDefaultAsync(p => p.Id == id);
            if (process == null)
                return NotFound();

            _context.Incidents.RemoveRange(process.Components);
            _context.Processes.Remove(process);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Process>> UpdateProcess(int id, [FromBody] UpdateProcessDto process)
        {
            var _process = await _context.Processes.FirstOrDefaultAsync(mach => mach.Id == id);
            if (_process == null)
                return NotFound();
            _process.Update(process.Name);
            await _context.SaveChangesAsync();
            return Ok(_process);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProcessDto process)
        {
            if (process == null)
                return BadRequest();
            var machine = GetID(process.MachineId);
            if (machine == null)
                return NotFound(machine);
            //

            var _process = new Process(process.Name,process.MachineId);
            _context.Processes.Add(_process);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetID), new { id = _process.Id }, _process);
        }

    }
}
