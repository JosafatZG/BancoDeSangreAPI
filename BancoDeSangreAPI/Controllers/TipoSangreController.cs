using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BancoDeSangreAPI.Context;
using BancoDeSangreAPI.Models;

namespace BancoDeSangreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoSangreController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TipoSangreController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/TipoSangres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoSangre>>> GetTipoSangre()
        {
            return await _context.TipoSangre.ToListAsync();
        }

        // GET: api/TipoSangres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoSangre>> GetTipoSangre(int id)
        {
            var tipoSangre = await _context.TipoSangre.FindAsync(id);

            if (tipoSangre == null)
            {
                return NotFound();
            }

            return tipoSangre;
        }

        // PUT: api/TipoSangres/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoSangre(int id, TipoSangre tipoSangre)
        {
            if (id != tipoSangre.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoSangre).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoSangreExists(id))
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

        // POST: api/TipoSangres
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TipoSangre>> PostTipoSangre(TipoSangre tipoSangre)
        {
            _context.TipoSangre.Add(tipoSangre);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoSangre", new { id = tipoSangre.Id }, tipoSangre);
        }

        // DELETE: api/TipoSangres/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoSangre>> DeleteTipoSangre(int id)
        {
            var tipoSangre = await _context.TipoSangre.FindAsync(id);
            if (tipoSangre == null)
            {
                return NotFound();
            }

            _context.TipoSangre.Remove(tipoSangre);
            await _context.SaveChangesAsync();

            return tipoSangre;
        }

        private bool TipoSangreExists(int id)
        {
            return _context.TipoSangre.Any(e => e.Id == id);
        }
    }
}
