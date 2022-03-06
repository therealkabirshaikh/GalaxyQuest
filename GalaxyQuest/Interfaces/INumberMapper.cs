namespace GalaxyQuest.Interfaces
{
    public interface INumberMapper
    {
        void Map(string galactic, string roman);
        Dictionary<string, string> GetMap();
        void SetCommodityPrice(string commodity, decimal quantity, decimal totalValue);
        decimal GetCommodityPrice(string commodityName);
    }
}