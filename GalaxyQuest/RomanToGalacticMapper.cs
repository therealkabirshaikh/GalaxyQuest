using System.Collections.Generic;

namespace GalaxyQuest
{
    public static class RomanToGalacticMapper
    {
        private static Dictionary<string, string> romanToInterGalacticMap = new();
        
        public static void Map(string galactic, string roman)
        {
            romanToInterGalacticMap.Add(galactic, roman);
        }

        public static Dictionary<string,string> GetMap()
        {
            return romanToInterGalacticMap;
        }
    }
}
