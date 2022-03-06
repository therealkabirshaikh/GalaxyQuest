using GalaxyQuest.Models;

namespace GalaxyQuest.Interfaces
{
    public interface ICurrencyConverter
    {
        ReturnDTO GetCommodityData(string inputArray);
        void CalculateCommodityPrice(IReadOnlyList<string> galacticRoman);
        ReturnDTO CalculateArabicValue(string input);
    }
}