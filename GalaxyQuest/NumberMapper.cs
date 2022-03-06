using GalaxyQuest.Interfaces;

namespace GalaxyQuest
{
    public class NumberMapper : INumberMapper
    {
        private static readonly Dictionary<string, string> RomanToInterGalacticMap = new();
        private static readonly Dictionary<string, decimal> CommodityPriceMap = new();

        public void MapGalacticToRoman(string galactic, string roman)
        {
            if (RomanToInterGalacticMap.ContainsKey(galactic))
            {
                RomanToInterGalacticMap.Remove(galactic);
            }
            RomanToInterGalacticMap.Add(galactic, roman.ToUpper());
        }

        public Dictionary<string, string> GetGalacticToRomanMap()
        {
            return RomanToInterGalacticMap;
        }

        public void SetCommodityPrice(string commodity, decimal quantity, decimal totalValue)
        {
            var commodityPrice = totalValue / quantity;
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