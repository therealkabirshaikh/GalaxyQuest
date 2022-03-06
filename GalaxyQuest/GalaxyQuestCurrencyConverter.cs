using System;
using System.Collections.Generic;
using System.Linq;
using GalaxyQuest.Models;

namespace GalaxyQuest
{
    public class GalaxyQuestCurrencyConverter
    {
        public static ArabicNumber CalculateArabicValue(IReadOnlyList<string> inputArray)
        {
            var localRoman = string.Empty;
            var message = string.Empty;
            var galacticNames = inputArray[1].Split(' ');
            foreach (var name in galacticNames)
            {
                if (name.Equals(string.Empty))
                    continue;
                Dictionary<string, string> map = RomanToGalacticMapper.GetMap();

                if (map.TryGetValue(name, out _))
                    localRoman += map[name];
                else
                {
                    message = "I have no idea what you are talking about";
                }
            }

            var convertedValue = RomanArabicConverter.ToArabicNumber(localRoman);

            return new ArabicNumber {Message = message, Number = convertedValue};
        }

        public static Commodity GetCommodityValue(IReadOnlyList<string> inputArray)
        {
            var localRoman = string.Empty;
            var message = string.Empty;
            var galacticValueAndCommodity = inputArray[1].Split(' ');
            var commodity = galacticValueAndCommodity.TakeLast(1).First();
            Array.Resize(ref galacticValueAndCommodity, galacticValueAndCommodity.Length - 1);
            foreach (var name in galacticValueAndCommodity)
            {
                if (name.Equals(string.Empty))
                    continue;

                Dictionary<string, string> map = RomanToGalacticMapper.GetMap();
                if (map.TryGetValue(name, out _))
                    localRoman += map[name];
                else
                {
                    message = "I have no idea what you are talking about";
                }
            }

            var convertedValue = RomanArabicConverter.ToArabicNumber(localRoman);
            var commodityValue = RomanToGalacticMapper.GetCommodityValue(commodity);
            var totalValue = commodityValue * convertedValue;

            return new Commodity {Number = totalValue, Message = message};
        }

        public static void CalculateCommodityPrice(IReadOnlyList<string> galacticRoman)
        {
            var localRoman = string.Empty;
            var numberOfCredits = galacticRoman[1].Split(' ');
            var galacticNames = galacticRoman[0].Split(' ');
            foreach (var name in galacticNames)
            {
                Dictionary<string, string> map = RomanToGalacticMapper.GetMap();
                if (map.ContainsKey(name))
                {
                    localRoman += map[name];
                }
                else
                {
                    var convertedValue = RomanArabicConverter.ToArabicNumber(localRoman);
                    var credits = numberOfCredits[0];
                    if (decimal.TryParse(credits, out var totalValue))
                        SetCommodityPrice(convertedValue, galacticNames.Last(),
                            totalValue);
                    else
                    {
                        Console.WriteLine("I have no idea what you are talking about");
                    }
                }
            }
        }

        private static void SetCommodityPrice(decimal convertedValue, string g, decimal totalValue)
        {
            RomanToGalacticMapper.SetCommodityPrice(convertedValue, g, totalValue);
        }
    }
}