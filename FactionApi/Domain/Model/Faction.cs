namespace FactionApi.Domain.Model;

public class Faction
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Logo { get; set; }
    public int Leader { get; set; }
    public int HQLocationID { get; set; }
}