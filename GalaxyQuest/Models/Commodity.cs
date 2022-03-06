using System;

namespace GalaxyQuest.Models
{
    public record Commodity
    {
        public decimal Number {get; init; }
        public string Message { get; init; }
    }
}