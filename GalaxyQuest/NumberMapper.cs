using GalaxyQuest.Interfaces;

namespace GalaxyQuest
{
    public class NumberMapper : INumberMapper
    {
        private static readonly Dictionary<string, string> RomanToInterGalacticMap = new();
        private static readonly Dictionary<string, decimal> CommodityPriceMap = new();

        public void Map(string galactic, string roman)
        {
            if (RomanToInterGalacticMap.ContainsKey(galactic))
            {
                RomanToInterGalacticMap.Remove(galactic);
            }
            RomanToInterGalacticMap.Add(galactic, roman.ToUpper());
        }

        public Dictionary<string, string> GetMap()
        {
            return RomanToInterGalacticMap;
        }

        public void SetCommodityPrice(string commodity, decimal arabicValue, decimal totalValue)
        {
            var commodityPrice = totalValue / arabicValue;
            if (CommodityPriceMap.ContainsKey(commodity))
            {
                CommodityPriceMap.Remove(commodity);
            }

            CommodityPriceMap.Add(commodity, commodityPrice);
        }

        public decimal GetCommodityPrice(string commodityName)
        {
            CommodityPriceMap.TryGetValue(commodityName, out var value);
            return value;
        }
    }
}