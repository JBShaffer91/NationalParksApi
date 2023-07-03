namespace NationalParksApi.Models
{
  public class Park
  {
    public int Id { get; set; }
    public string? ParkName { get; set; }
    public string? State { get; set; }
    public string? Description { get; set; }
    public string? Activities { get; set; }
  }
}
