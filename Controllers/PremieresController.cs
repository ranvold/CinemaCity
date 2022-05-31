using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CinemaCity.Models;

namespace CinemaCity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PremieresController : Controller
    {
        private readonly CinemaCityAPIContext _context;

        public PremieresController(CinemaCityAPIContext context)
        {
            _context = context;
        }

        // GET: api/Premieres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Premiere>>> GetPremieres()
        {
            return await _context.Premieres.ToListAsync();
        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Premiere>> GetPremiere(int? id)
        {
            if (id == null || _context.Premieres == null)
            {
                return NotFound();
            }

            var premiere = await _context.Premieres
                .FirstOrDefaultAsync(m => m.Id == id);
            if (premiere == null)
            {
                return NotFound();
            }

            return premiere;
        }

        // PUT: api/Premieres/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, Premiere premiere)
        {
            if (id != premiere.Id)
            {
                return BadRequest();
            }

            _context.Entry(premiere).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PremiereExists(id))
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

        // POST: api/Premieres
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<ActionResult<Premiere>> PostMovie(Premiere premiere)
        {
            _context.Premieres.Add(premiere);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPremiere", new { id = premiere.Id }, premiere);
        }

        // Delete: api/Premieres/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Premiere>> DeletePremiere(int id)
        {
            var premiere = await _context.Premieres.FindAsync(id);
            if (premiere == null)
            {
                return NotFound();
            }

            _context.Premieres.Remove(premiere);
            await _context.SaveChangesAsync();

            return premiere;
        }

        private bool PremiereExists(int id)
        {
          return _context.Premieres.Any(e => e.Id == id);
        }
    }
}
