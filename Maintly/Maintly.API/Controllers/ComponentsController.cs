using Maintly.API.Data;
using Maintly.API.DTOs;
using Maintly.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Maintly.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ComponentsController: ControllerBase
    {
        private readonly MaintlyContext _context;
        public ComponentsController(MaintlyContext context)
        {
            _context = context;
        }
        [HttpGet(Name = "GetComponents")]
        public async Task<ActionResult<IEnumerable<Component>>> Get() //dzieki Ienumerable moge zrobic metode co na dole dzieki niemu mozna przeiterowac jakies listy itp
        {
            return await _context.Components.ToListAsync();
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Component>> GetID(int id)
        {
            var component = await _context.Components.FirstOrDefaultAsync(mach => mach.Id == id);
            if (component == null) return NotFound();
            return component;
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Component>> DeleteByID(int id)
        {
            var component = await _context.Components.FirstOrDefaultAsync(mach => mach.Id == id);
            if (component == null)
                return NotFound();
            _context.Components.Remove(component);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Component>> UpdateComponent(int id, [FromBody] UpdateComponentDto component)
        {
            var _component = await _context.Components.FirstOrDefaultAsync(mach => mach.Id == id);
            if (_component == null)
                return NotFound();
            _component.Update(component.Name, component.ComponentType);
            await _context.SaveChangesAsync();
            return Ok(_component);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateComponentDto component)
        {
            if (component == null)
                return BadRequest();
            var process = GetID(component.ProcessId);
            if (process == null)
                return NotFound(process);
            //

            var _component = new Component(component.Name, component.ComponentType, component.ProcessId);
            _context.Components.Add(_component);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetID), new { id = _component.Id }, _component);
        }

    }
}
