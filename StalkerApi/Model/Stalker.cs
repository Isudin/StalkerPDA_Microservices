namespace StalkerApi;

public class Stalker
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Nickname { get; set; }
    public StalkerStatus Status { get; set; }
    public int CurrentLocationID { get; set; }
}

public enum StalkerStatus
{
    Unknown,
    Alive,
    Dead,
    Zombified
}