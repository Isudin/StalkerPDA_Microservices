namespace StalkerApi.Core.Model;

public record Stalker(int Id, string Name, string Surname, string Nickname, 
    StalkerStatus Status, int CurrentLocationID, int ReputationPoints);

public enum StalkerStatus
{
    Unknown,
    Alive,
    Dead,
    Zombified
}