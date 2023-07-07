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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Park>().HasData(
        new Park { Id = 1, ParkName = "Yellowstone", State = "Wyoming", Description = "First national park in the world.", Activities = "Hiking, Wildlife Viewing, Camping" },
        new Park { Id = 2, ParkName = "Yosemite", State = "California", Description = "Famous for its waterfalls.", Activities = "Hiking, Rock Climbing, Camping" },
        new Park { Id = 3, ParkName = "Grand Canyon", State = "Arizona", Description = "Known for its visually overwhelming size.", Activities = "Hiking, Rafting, Helicopter Tours" }
      );
    }
  }
}
