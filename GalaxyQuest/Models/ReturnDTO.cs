namespace GalaxyQuest.Models
{
    public record ReturnDTO
    {
        public decimal Number {get; init; }
        public string? Message { get; init; }
    }
}