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
    public class TypeIllustrationsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TypeIllustrationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/TypeIllustrations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeIllustration>>> GetTypeIllustration()
        {
            return await _context.TypeIllustration.ToListAsync();
        }

        // GET: api/TypeIllustrations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TypeIllustration>> GetTypeIllustration(int id)
        {
            var typeIllustration = await _context.TypeIllustration.FindAsync(id);

            if (typeIllustration == null)
            {
                return NotFound();
            }

            return typeIllustration;
        }

        // PUT: api/TypeIllustrations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypeIllustration(int id, TypeIllustration typeIllustration)
        {
            if (id != typeIllustration.Id)
            {
                return BadRequest();
            }

            _context.Entry(typeIllustration).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeIllustrationExists(id))
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

        // POST: api/TypeIllustrations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TypeIllustration>> PostTypeIllustration(TypeIllustration typeIllustration)
        {
            _context.TypeIllustration.Add(typeIllustration);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTypeIllustration", new { id = typeIllustration.Id }, typeIllustration);
        }

        // DELETE: api/TypeIllustrations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTypeIllustration(int id)
        {
            var typeIllustration = await _context.TypeIllustration.FindAsync(id);
            if (typeIllustration == null)
            {
                return NotFound();
            }

            _context.TypeIllustration.Remove(typeIllustration);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TypeIllustrationExists(int id)
        {
            return _context.TypeIllustration.Any(e => e.Id == id);
        }
    }
}
