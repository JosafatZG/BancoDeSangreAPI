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
    public class TipoRHController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TipoRHController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/TipoRH
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoRH>>> GetTipoRH()
        {
            return await _context.TipoRH.ToListAsync();
        }

        // GET: api/TipoRH/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoRH>> GetTipoRH(int id)
        {
            var tipoRH = await _context.TipoRH.FindAsync(id);

            if (tipoRH == null)
            {
                return NotFound();
            }

            return tipoRH;
        }

        // PUT: api/TipoRH/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoRH(int id, TipoRH tipoRH)
        {
            if (id != tipoRH.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoRH).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoRHExists(id))
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

        // POST: api/TipoRH
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TipoRH>> PostTipoRH(TipoRH tipoRH)
        {
            _context.TipoRH.Add(tipoRH);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoRH", new { id = tipoRH.Id }, tipoRH);
        }

        // DELETE: api/TipoRH/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoRH>> DeleteTipoRH(int id)
        {
            var tipoRH = await _context.TipoRH.FindAsync(id);
            if (tipoRH == null)
            {
                return NotFound();
            }

            _context.TipoRH.Remove(tipoRH);
            await _context.SaveChangesAsync();

            return tipoRH;
        }

        private bool TipoRHExists(int id)
        {
            return _context.TipoRH.Any(e => e.Id == id);
        }
    }
}
