using GalaxyQuest.Models;

namespace GalaxyQuest.Interfaces
{
    public interface ICurrencyConverter
    {
        ReturnDTO GetCommodityPrice(string inputArray);
        void CalculateCommodityPrice(IReadOnlyList<string> galacticRoman);
        ReturnDTO CalculateArabicValue(string input);
    }
}