using Maintly.API.Data;
using Maintly.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Maintly.API.DTOs;

namespace Maintly.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MachinesController: ControllerBase
    {
        private readonly MaintlyContext _context;
        public MachinesController(MaintlyContext context)
        {
            _context = context;
        }
        [HttpGet(Name = "GetMachines")]
        public async Task<ActionResult<IEnumerable<Machine>>> Get() //dzieki Ienumerable moge zrobic metode co na dole dzieki niemu mozna przeiterowac jakies listy itp
        {
            return await _context.Machines.Include(m => m.Processes).ThenInclude(p => p.Components).ToListAsync();
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Machine>> GetID(int id)
        {
            var machine = await _context.Machines.Include(m => m.Processes).ThenInclude(p => p.Components).FirstOrDefaultAsync(d => d.Id == id);
            if (machine == null) return NotFound();
            return machine;
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Machine>> DeleteByID(int id)
        {
            var machine = await _context.Machines.Include(p => p.Processes).ThenInclude(c => c.Components).FirstOrDefaultAsync(m => m.Id == id);
            if (machine == null)
                return NotFound();
            foreach (var process in machine.Processes)
            {
                _context.RemoveRange(process.Components);   
            }
            _context.Processes.RemoveRange(machine.Processes);
            _context.Machines.Remove(machine);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Machine>> UpdateMachine(int id,[FromBody] UpdateMachineDto machine)
        {
            var _machine = await _context.Machines.FirstOrDefaultAsync(mach => mach.Id == id);
            if (_machine == null)
                return NotFound();
            _machine.Update(machine.Name);
            await _context.SaveChangesAsync();
            return Ok(_machine);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMachineDto machine) 
        {
            if (machine == null)
                return BadRequest();
            var _machine = new Machine(machine.Name);
            _context.Machines.Add(_machine);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetID), new {id = _machine.Id}, _machine);
        }
        //[HttpPost] – endpoint obsługuje tworzenie danych.
        //[FromBody] – dane przychodzą z treści żądania HTTP.
        //Machine machine – ASP.NET Core zamieni przesłany JSON na obiekt C#.
        //IActionResult – pozwala zwrócić odpowiedź HTTP.


        //sqlite
        //ORM – mapuje obiekty C# na dane w bazie.
        //DbContext – główny obiekt EF Core, przez który komunikujemy się z bazą.
        //DbSet – reprezentuje kolekcję encji, np.maszyn, w bazie danych.
    }
}
