using System.Collections.Generic;

namespace GalaxyQuest
{
    public static class RomanToGalacticMapper
    {
        private static readonly Dictionary<string, string> RomanToInterGalacticMap = new();
        private static readonly Dictionary<string, decimal> CommodityPriceMap = new();

        public static void Map(string galactic, string roman)
        {
            RomanToInterGalacticMap.Add(galactic, roman.ToUpper());
        }

        public static Dictionary<string, string> GetMap()
        {
            return RomanToInterGalacticMap;
        }

        public static void SetCommodityPrice(decimal arabicValue, string galactic, decimal totalValue)
        {
            var commodityPrice = totalValue / arabicValue;
            if (CommodityPriceMap.ContainsKey(galactic))
            {
                CommodityPriceMap.Remove(galactic);
            }

            CommodityPriceMap.Add(galactic, commodityPrice);
        }

        public static decimal GetCommodityValue(string commodityName)
        {
            CommodityPriceMap.TryGetValue(commodityName, out var value);
            return value;
        }
    }
}