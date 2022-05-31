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
    public class MoviesActorsPremieresController : Controller
    {
        private readonly CinemaCityAPIContext _context;

        public MoviesActorsPremieresController(CinemaCityAPIContext context)
        {
            _context = context;
        }

        // GET: Api/MoviesActorsPremieres
        public async Task<ActionResult<IEnumerable<MoviesActorsPremiere>>> GetMoviesActorsPremieres()
        {
            return await _context.MoviesActorsPremieres.ToListAsync();
        }

        // GET: api/MoviesActorsPremieres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MoviesActorsPremiere>> GetMoviesActorsPremiere(int? id)
        {
            if (id == null || _context.MoviesActorsPremieres == null)
            {
                return NotFound();
            }

            var moviesActorsPremiere = await _context.MoviesActorsPremieres
                .FirstOrDefaultAsync(m => m.Id == id);
            if (moviesActorsPremiere == null)
            {
                return NotFound();
            }

            return moviesActorsPremiere;
        }

        // PUT: api/MoviesActorsPremieres/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMoviesActorsPremiere(int id, MoviesActorsPremiere moviesActorsPremiere)
        {
            if (id != moviesActorsPremiere.Id)
            {
                return BadRequest();
            }

            _context.Entry(moviesActorsPremiere).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MoviesActorsPremiereExists(id))
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

        // POST: api/MoviesActorsPremieres
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<ActionResult<MoviesActorsPremiere>> PostMoviesActorsPremiere(MoviesActorsPremiere moviesActorsPremiere)
        {
            _context.MoviesActorsPremieres.Add(moviesActorsPremiere);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMoviesActorsPremiere", new { id = moviesActorsPremiere.Id }, moviesActorsPremiere);
        }

        // Delete: api/MoviesActorsPremieres/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MoviesActorsPremiere>> DeleteMoviesActorsPremiere(int id)
        {
            var moviesActorsPremiere = await _context.MoviesActorsPremieres.FindAsync(id);
            if (moviesActorsPremiere == null)
            {
                return NotFound();
            }

            _context.MoviesActorsPremieres.Remove(moviesActorsPremiere);
            await _context.SaveChangesAsync();

            return moviesActorsPremiere;
        }

        private bool MoviesActorsPremiereExists(int id)
        {
          return _context.MoviesActorsPremieres.Any(e => e.Id == id);
        }
    }
}
