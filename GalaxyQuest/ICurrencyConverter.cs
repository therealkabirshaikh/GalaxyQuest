using System.Collections.Generic;
using GalaxyQuest.Models;

namespace GalaxyQuest
{
    public interface ICurrencyConverter
    {
        ReturnDTO GetCommodityValue(IReadOnlyList<string> inputArray);
        void CalculateCommodityPrice(IReadOnlyList<string> galacticRoman);
    }
}