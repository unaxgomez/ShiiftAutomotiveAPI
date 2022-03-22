using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShiiftAutomotiveAPI.Models;

namespace ShiiftAutomotiveAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IllustrationsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public IllustrationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Illustrations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Illustration>>> GetIllustration()
        {
            return await _context.Illustration.ToListAsync();
        }

        // GET: api/Illustrations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Illustration>> GetIllustration(int id)
        {
            var illustration = await _context.Illustration.FindAsync(id);

            if (illustration == null)
            {
                return NotFound();
            }

            return illustration;
        }

        // PUT: api/Illustrations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIllustration(int id, Illustration illustration)
        {
            if (id != illustration.Id)
            {
                return BadRequest();
            }

            _context.Entry(illustration).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IllustrationExists(id))
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

        // POST: api/Illustrations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Illustration>> PostIllustration(Illustration illustration)
        {
            _context.Illustration.Add(illustration);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIllustration", new { id = illustration.Id }, illustration);
        }

        // DELETE: api/Illustrations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIllustration(int id)
        {
            var illustration = await _context.Illustration.FindAsync(id);
            if (illustration == null)
            {
                return NotFound();
            }

            _context.Illustration.Remove(illustration);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IllustrationExists(int id)
        {
            return _context.Illustration.Any(e => e.Id == id);
        }
    }
}
