using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VechileApplication.Models;

namespace VechileApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MakesController : ControllerBase
    {
        private readonly vehicleDbContext _context;

        public MakesController(vehicleDbContext context)
        {
            _context = context;
        }

        // GET: api/Makes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Make>>> GetMake()
        {
            return await _context.Make.ToListAsync();
        }

        // GET: api/Makes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Make>> GetMake(int id)
        {
            var make = await _context.Make.FindAsync(id);

            if (make == null)
            {
                return NotFound();
            }

            return make;
        }

        // PUT: api/Makes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMake(int id, Make make)
        {
            if (id != make.make_id)
            {
                return BadRequest();
            }

            _context.Entry(make).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MakeExists(id))
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

        // POST: api/Makes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Make>> PostMake(Make make)
        {
            _context.Make.Add(make);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMake", new { id = make.make_id }, make);
        }

        // DELETE: api/Makes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMake(int id)
        {
            var make = await _context.Make.FindAsync(id);
            if (make == null)
            {
                return NotFound();
            }

            _context.Make.Remove(make);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MakeExists(int id)
        {
            return _context.Make.Any(e => e.make_id == id);
        }
    }
}
