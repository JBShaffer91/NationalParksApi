using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NationalParksApi.Data;
using NationalParksApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NationalParksApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ParksController : ControllerBase
  {
    private readonly ParkDbContext _context;

    public ParksController(ParkDbContext context)
    {
      _context = context;
    }

    // GET: api/Parks
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Park>>> GetParks([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
      var parks = await _context.Parks
      .Skip((pageNumber - 1) * pageSize)
      .Take(pageSize)
      .ToListAsync();

      if (parks == null || !parks.Any())
      {
        return NotFound("No parks found.");
      }

      return parks;
    }

    // POST: api/Parks
    [HttpPost]
    public async Task<ActionResult<Park>> CreatePark(Park park)
    {
      _context.Parks.Add(park);
      await _context.SaveChangesAsync();

      return CreatedAtAction(nameof(GetPark), new { id = park.Id }, park);
    }

    // GET: api/Parks/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Park>> GetPark(int id)
    {
      var park = await _context.Parks.FindAsync(id);

      if (park == null)
      {
        return BadRequest("Oops! Looks like that park doesn't exist.");
      }

      return park;
    }

    // PUT: api/Parks/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePark(int id, Park park)
    {
      if (id != park.Id)
      {
        return BadRequest("The ID in the URL does not match the ID of the park to update.");
      }

      _context.Entry(park).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ParkExists(id))
        {
          return BadRequest("Oops! Looks like that park doesn't exist.");
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    // DELETE: api/Parks/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePark(int id)
    {
      var park = await _context.Parks.FindAsync(id);
      if (park == null)
      {
        return BadRequest("Oops! Looks like that park doesn't exist.");
      }

      _context.Parks.Remove(park);
      await _context.SaveChangesAsync();

      return NoContent();
    }

    private bool ParkExists(int id)
    {
      return _context.Parks.Any(e => e.Id == id);
    }
  }
}
