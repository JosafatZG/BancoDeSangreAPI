using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BancoDeSangreAPI.Context;
using BancoDeSangreAPI.Models;
using BancoDeSangreAPI.Dto;

namespace BancoDeSangreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacientesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PacientesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Pacientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PacienteDTO>>> GetPaciente()
        {
            return await _context.Paciente.ToListAsync();
        }
        [HttpGet("Buscar")]
        public async Task<ActionResult<IEnumerable<PacienteDTO>>> GetPaciente([FromQuery] string nombre)
        {
            if(string.IsNullOrEmpty(nombre))
                return await _context.Paciente.ToListAsync();
            else
            return await _context.Paciente.Where(p => (p.Nombres + " " + p.Apellidos).ToLower().Contains(nombre)).ToListAsync();
        }

        // GET: api/Pacientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PacienteDTO>> GetPaciente(int id)
        {
            var paciente = await _context.Paciente.FindAsync(id);

            if (paciente == null)
            {
                return NotFound();
            }

            return paciente;
        }

        // PUT: api/Pacientes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaciente(int id, PacienteDTO paciente)
        {
            if (id != paciente.Id)
            {
                return BadRequest();
            }

            try
            {
                var pacienteF = await _context.Paciente.FindAsync(id);
                if(paciente != null)
                {
                    pacienteF.Nombres = paciente.Nombres;
                    pacienteF.Apellidos = paciente.Apellidos;
                    pacienteF.TipoSangreId = paciente.TipoSangreId;
                    pacienteF.TipoRHId = paciente.TipoRHId;
                    await _context.SaveChangesAsync();
                    return Ok();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PacienteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Pacientes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Paciente>> PostPaciente(PacienteDTO paciente)
        {
            _context.Paciente.Add(paciente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaciente", new { id = paciente.Id }, paciente);
        }

        // DELETE: api/Pacientes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PacienteDTO>> DeletePaciente(int id)
        {
            var paciente = await _context.Paciente.FindAsync(id);
            if (paciente == null)
            {
                return NotFound();
            }

            await _context.Database.ExecuteSqlRawAsync("DELETE FROM paciente WHERE Id = {0}", id);
            //_context.Paciente.Remove(paciente);
            //await _context.SaveChangesAsync();

            return paciente;
        }

        private bool PacienteExists(int id)
        {
            return _context.Paciente.Any(e => e.Id == id);
        }
    }
}
