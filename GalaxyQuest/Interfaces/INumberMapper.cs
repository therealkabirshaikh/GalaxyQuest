namespace GalaxyQuest.Interfaces
{
    public interface INumberMapper
    {
        void Map(string galactic, string roman);
        Dictionary<string, string> GetMap();
        void SetCommodityPrice(decimal arabicValue, string galactic, decimal totalValue);
        decimal GetCommodityValue(string commodityName);
    }
}