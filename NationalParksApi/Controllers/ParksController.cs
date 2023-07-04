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
    public async Task<ActionResult<IEnumerable<Park>>> GetParks()
    {
      return await _context.Parks.ToListAsync();
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
  }
}
