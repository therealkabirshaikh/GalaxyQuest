using GalaxyQuest.Interfaces;

namespace GalaxyQuest
{
    public class NumberMapper : INumberMapper
    {
        private static readonly Dictionary<string, string> RomanToInterGalacticMap = new();
        private static readonly Dictionary<string, decimal> CommodityPriceMap = new();

        public void Map(string galactic, string roman)
        {
            RomanToInterGalacticMap.Add(galactic, roman.ToUpper());
        }

        public Dictionary<string, string> GetMap()
        {
            return RomanToInterGalacticMap;
        }

        public void SetCommodityPrice(decimal arabicValue, string galactic, decimal totalValue)
        {
            var commodityPrice = totalValue / arabicValue;
            if (CommodityPriceMap.ContainsKey(galactic))
            {
                CommodityPriceMap.Remove(galactic);
            }

            CommodityPriceMap.Add(galactic, commodityPrice);
        }

        public decimal GetCommodityValue(string commodityName)
        {
            CommodityPriceMap.TryGetValue(commodityName, out var value);
            return value;
        }
    }
}