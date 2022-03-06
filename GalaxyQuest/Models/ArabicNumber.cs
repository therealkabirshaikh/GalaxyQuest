using System;

namespace GalaxyQuest.Models
{
    public record ArabicNumber
    {
        public decimal Number {get; init; }
        public string Message { get; init; }
    }
}