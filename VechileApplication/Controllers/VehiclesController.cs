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
    public class VehiclesController : ControllerBase
    {
        private readonly vehicleDbContext _context;

        public VehiclesController(vehicleDbContext context)
        {
            _context = context;
        }

        // GET: api/Vehicles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetVehicles()
        {
            var  joint1  = _context.Vehicles.Join(_context.Price, vechilesTable => vechilesTable.v_id, priceTable => priceTable.v_id,
                (vechilesTable, priceTable) => new { vechilesTable, priceTable }).Join(_context.Models, joinedTable => 
                joinedTable.vechilesTable.model_id, modelsTable => modelsTable.model_id, (joinedTable, modelsTable)
                => new { vehicleName = joinedTable.vechilesTable.v_name, price = joinedTable.priceTable.price, modelName = modelsTable.model_name });

            await joint1.LoadAsync();
            var newVar = await joint1.ToListAsync();
            return newVar;
        }



        // GET: api/Vehicles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vehicles>> GetVehicles(int id)
        {
            var vehicles = await _context.Vehicles.FindAsync(id);

            if (vehicles == null)
            {
                return NotFound();
            }

            return vehicles;
        }

        // PUT: api/Vehicles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehicles(int id, Vehicles vehicles)
        {
            if (id != vehicles.v_id)
            {
                return BadRequest();
            }

            _context.Entry(vehicles).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehiclesExists(id))
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

        // POST: api/Vehicles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vehicles>> PostVehicles(Vehicles vehicles)
        {
            _context.Vehicles.Add(vehicles);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVehicles", new { id = vehicles.v_id }, vehicles);
        }

        // DELETE: api/Vehicles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicles(int id)
        {
            var vehicles = await _context.Vehicles.FindAsync(id);
            if (vehicles == null)
            {
                return NotFound();
            }

            _context.Vehicles.Remove(vehicles);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VehiclesExists(int id)
        {
            return _context.Vehicles.Any(e => e.v_id == id);
        }
    }
}
