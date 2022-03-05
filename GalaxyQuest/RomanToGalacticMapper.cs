using System.Collections.Generic;

namespace GalaxyQuest
{
    public static class RomanToGalacticMapper
    {
        private static Dictionary<string, string> romanToInterGalacticMap = new();
        private static Dictionary<string, decimal> commodityPriceMap = new();

        public static void Map(string galactic, string roman)
        {
            romanToInterGalacticMap.Add(galactic, roman.ToUpper());
        }

        public static Dictionary<string,string> GetMap()
        {
            return romanToInterGalacticMap;
        }

        public static void SetCommodityPrice(decimal arabicValue, string galactic, decimal totalValue)
        {
            var commodityPrice = totalValue / arabicValue;
            if(commodityPriceMap.ContainsKey(galactic))
            {
                commodityPriceMap.Remove(galactic);
            }
            commodityPriceMap.Add(galactic, commodityPrice);
        }

        public static decimal GetCommodityValue(string commodityName)
        {
            commodityPriceMap.TryGetValue(commodityName, out decimal value);
            return value;
        }
    }
}
