using System;
using System.Linq;
using System.Collections.Generic;

namespace GalaxyQuest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = string.Empty;
            Console.WriteLine("Enter notes");
            while (input != "exit")
            {
                input = Console.ReadLine();
                var startIndex = input.LastIndexOf('?');

                if (startIndex != -1)
                {
                    input = input.Remove(startIndex);
                }
                input = input.Trim();

                if (input.Contains(" is ", StringComparison.OrdinalIgnoreCase))
                {
                    string[] inputArray = input.Split(" is ");
                    if (inputArray[0].Equals("how much", StringComparison.OrdinalIgnoreCase))
                    {
                        CalculateArabicValue(inputArray);
                    }
                    else if (inputArray[0].StartsWith("how many", StringComparison.OrdinalIgnoreCase))
                    {
                        GetCommodityValue(inputArray);
                    }
                    else
                    {
                        if (inputArray[1].EndsWith("credits", StringComparison.OrdinalIgnoreCase))
                        {
                            CalculateCommodityPrice(inputArray);
                        }
                        else
                        {
                            RomanToGalacticMapper.Map(inputArray[0], inputArray[1]);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("I have no idea what you are talking about");
                }
            }
        }

        private static void CalculateArabicValue(string[] inputArray)
        {
            var localRoman = string.Empty;

            var galacticNames = inputArray[1].Split(' ');
            foreach (var g in galacticNames)
            {
                if (g.Equals(string.Empty))
                    continue;
                Dictionary<string, string> valueMap = RomanToGalacticMapper.GetMap();
                localRoman += valueMap[g];
            }

            var convertedValue = Roman.From(localRoman);
            if (convertedValue >= 0)
            {
                Console.WriteLine($"{inputArray[1]} is {convertedValue}");
            }
            else
            {
                Console.WriteLine($"{inputArray[1]} is an invalid value");
            }
        }

        private static void GetCommodityValue(string[] inputArray)
        {
            var localRoman = string.Empty;
            var galacticAndMetal = inputArray[1].Split(' ');
            foreach (var g in galacticAndMetal)
            {
                if (g.Equals(string.Empty))
                    continue;

                Dictionary<string, string> valueMap1 = RomanToGalacticMapper.GetMap();
                if (valueMap1.ContainsKey(g))
                {
                    localRoman += valueMap1[g];
                }
                else //assume precious metal
                {
                    var convertedValue = Roman.From(localRoman);
                    var commodityValue = RomanToGalacticMapper.GetCommodityValue(g);
                    var totalValue = commodityValue * convertedValue;
                    if (totalValue >= 0)
                    {
                        Console.WriteLine($"{inputArray[1]} is {totalValue} Credits");
                    }
                    else
                    {
                        Console.WriteLine($"{inputArray[1]} is an invalid value");
                    }
                }
            }
        }

        private static void CalculateCommodityPrice(string[] galacticRoman)
        {
            var localRoman = string.Empty;
            var fred = galacticRoman[1].Split(' ');

            var galacticNames = galacticRoman[0].Split(' ');
            foreach (var g in galacticNames)
            {
                Dictionary<string, string> valueMap1 = RomanToGalacticMapper.GetMap();
                if (valueMap1.ContainsKey(g))
                {
                    localRoman += valueMap1[g];
                }
                else
                {
                    var convertedValue = Roman.From(localRoman);
                    var totalValue = Convert.ToDecimal(fred[0]);
                    SetCommodityPrice(convertedValue, galacticNames.Last(), totalValue);
                }
            }
        }

        private static void SetCommodityPrice(decimal convertedValue, string g, decimal totalValue)
        {
            RomanToGalacticMapper.SetCommodityPrice(convertedValue, g, totalValue);
        }
    }
}
