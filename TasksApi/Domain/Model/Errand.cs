namespace TasksApi.Domain.Model
{
    internal class Errand
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public int ReputationPointsEarned { get; set; }
        public int FactionId { get; set; }
    }
}
