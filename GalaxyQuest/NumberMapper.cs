using GalaxyQuest.Interfaces;

namespace GalaxyQuest
{
    public class NumberMapper : INumberMapper
    {
        private static readonly Dictionary<string, string> RomanToInterGalacticMap = new();
        private static readonly Dictionary<string, decimal> CommodityPriceMap = new();

        public bool MapGalacticToRoman(string galactic, string roman)
        {
            var validRomanChars = new[] {"i", "v", "x", "l", "c", "d", "m"};
            if (!validRomanChars.Contains(roman)) 
                return false;
            if (RomanToInterGalacticMap.ContainsKey(galactic))
            {
                RomanToInterGalacticMap.Remove(galactic);
            }
            RomanToInterGalacticMap.Add(galactic, roman);
            return true;
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