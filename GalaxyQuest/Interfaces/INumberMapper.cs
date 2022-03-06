﻿namespace GalaxyQuest.Interfaces
{
    public interface INumberMapper
    {
        void MapGalacticToRoman(string galactic, string roman);
        Dictionary<string, string> GetGalacticToRomanMap();
        void SetCommodityPrice(string commodity, decimal quantity, decimal totalValue);
        decimal GetCommodityPrice(string commodityName);
    }
}