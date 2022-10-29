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
    public class PricesController : ControllerBase
    {
        private readonly vehicleDbContext _context;

        public PricesController(vehicleDbContext context)
        {
            _context = context;
        }

        // GET: api/Prices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Price>>> GetPrice()
        {
            return await _context.Price.ToListAsync();
        }

        // GET: api/Prices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Price>> GetPrice(int id)
        {
            var price = await _context.Price.FindAsync(id);

            if (price == null)
            {
                return NotFound();
            }

            return price;
        }

        // PUT: api/Prices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrice(int id, Price price)
        {
            if (id != price.price_id)
            {
                return BadRequest();
            }

            _context.Entry(price).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PriceExists(id))
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

        // POST: api/Prices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Price>> PostPrice(Price price)
        {
            _context.Price.Add(price);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPrice", new { id = price.price_id }, price);
        }

        // DELETE: api/Prices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrice(int id)
        {
            var price = await _context.Price.FindAsync(id);
            if (price == null)
            {
                return NotFound();
            }

            _context.Price.Remove(price);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PriceExists(int id)
        {
            return _context.Price.Any(e => e.price_id == id);
        }
    }
}
