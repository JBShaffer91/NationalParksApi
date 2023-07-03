using Microsoft.EntityFrameworkCore;
using NationalParksApi.Models;

namespace NationalParksApi.Data
{
  public class ParkDbContext : DbContext
  {
    public ParkDbContext(DbContextOptions<ParkDbContext> options) : base(options)
    {
    }

    public DbSet<Park> Parks { get; set; } = null!;
  }
}
