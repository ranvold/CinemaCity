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
    public class MoviesGenresController : Controller
    {
        private readonly CinemaCityAPIContext _context;

        public MoviesGenresController(CinemaCityAPIContext context)
        {
            _context = context;
        }

        // GET: Api/MoviesGenres
        public async Task<ActionResult<IEnumerable<MoviesGenre>>> GetMoviesGenres()
        {
            return await _context.MoviesGenres.ToListAsync();
        }

        // GET: api/MoviesGenres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MoviesGenre>> GetMoviesGenre(int? id)
        {
            if (id == null || _context.MoviesGenres == null)
            {
                return NotFound();
            }

            var moviesGenre = await _context.MoviesGenres
                .FirstOrDefaultAsync(m => m.Id == id);
            if (moviesGenre == null)
            {
                return NotFound();
            }

            return moviesGenre;
        }

        // PUT: api/MoviesGenres/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMoviesActorsPremiere(int id, MoviesGenre moviesGenre)
        {
            if (id != moviesGenre.Id)
            {
                return BadRequest();
            }

            _context.Entry(moviesGenre).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MoviesGenreExists(id))
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

        // POST: api/MoviesGenres
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<ActionResult<MoviesGenre>> PostMoviesActorsPremiere(MoviesGenre moviesGenre)
        {
            _context.MoviesGenres.Add(moviesGenre);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMoviesGenre", new { id = moviesGenre.Id }, moviesGenre);
        }

        // Delete: api/MoviesGenres/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MoviesGenre>> DeleteMoviesGenre(int id)
        {
            var moviesGenre = await _context.MoviesGenres.FindAsync(id);
            if (moviesGenre == null)
            {
                return NotFound();
            }

            _context.MoviesGenres.Remove(moviesGenre);
            await _context.SaveChangesAsync();

            return moviesGenre;
        }

        private bool MoviesGenreExists(int id)
        {
          return _context.MoviesGenres.Any(e => e.Id == id);
        }
    }
}
