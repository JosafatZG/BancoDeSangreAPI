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
    public class BolsasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BolsasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Bolsas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bolsas>>> GetBolsas()
        {
            return await _context.Bolsas.ToListAsync();
        }

        // GET: api/Bolsas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bolsas>> GetBolsas(int id)
        {
            var bolsas = await _context.Bolsas.FindAsync(id);

            if (bolsas == null)
            {
                return NotFound();
            }

            return bolsas;
        }

        // PUT: api/Bolsas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBolsas(int id, Bolsas bolsas)
        {
            if (id != bolsas.Id)
            {
                return BadRequest();
            }

            _context.Entry(bolsas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BolsasExists(id))
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

        // POST: api/Bolsas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Bolsas>> PostBolsas(Bolsas bolsas)
        {
            _context.Bolsas.Add(bolsas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBolsas", new { id = bolsas.Id }, bolsas);
        }

        // DELETE: api/Bolsas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Bolsas>> DeleteBolsas(int id)
        {
            var bolsas = await _context.Bolsas.FindAsync(id);
            if (bolsas == null)
            {
                return NotFound();
            }

            _context.Bolsas.Remove(bolsas);
            await _context.SaveChangesAsync();

            return bolsas;
        }

        private bool BolsasExists(int id)
        {
            return _context.Bolsas.Any(e => e.Id == id);
        }
    }
}
