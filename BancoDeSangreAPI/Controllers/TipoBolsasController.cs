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
    public class TipoBolsasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TipoBolsasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/TipoBolsas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoBolsa>>> GetTipoBolsa()
        {
            return await _context.TipoBolsa.ToListAsync();
        }

        // GET: api/TipoBolsas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoBolsa>> GetTipoBolsa(int id)
        {
            var tipoBolsa = await _context.TipoBolsa.FindAsync(id);

            if (tipoBolsa == null)
            {
                return NotFound();
            }

            return tipoBolsa;
        }

        // PUT: api/TipoBolsas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoBolsa(int id, TipoBolsa tipoBolsa)
        {
            if (id != tipoBolsa.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoBolsa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoBolsaExists(id))
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

        // POST: api/TipoBolsas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TipoBolsa>> PostTipoBolsa(TipoBolsa tipoBolsa)
        {
            _context.TipoBolsa.Add(tipoBolsa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoBolsa", new { id = tipoBolsa.Id }, tipoBolsa);
        }

        // DELETE: api/TipoBolsas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoBolsa>> DeleteTipoBolsa(int id)
        {
            var tipoBolsa = await _context.TipoBolsa.FindAsync(id);
            if (tipoBolsa == null)
            {
                return NotFound();
            }

            _context.TipoBolsa.Remove(tipoBolsa);
            await _context.SaveChangesAsync();

            return tipoBolsa;
        }

        private bool TipoBolsaExists(int id)
        {
            return _context.TipoBolsa.Any(e => e.Id == id);
        }
    }
}
