using System;
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace GalaxyQuest
{
    internal class Program
    {
        private static void Main(string[] args)
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

        private static void CalculateArabicValue(IReadOnlyList<string> inputArray)
        {
            var localRoman = string.Empty;

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
                    Console.WriteLine("I have no idea what you are talking about");
                    return;
                }
            }

            var convertedValue = RomanArabicConverter.ToArabicNumber(localRoman);

            OutputWriter(inputArray, convertedValue);
        }

        private static void GetCommodityValue(IReadOnlyList<string> inputArray)
        {
            var localRoman = string.Empty;
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
                    Console.WriteLine("I have no idea what you are talking about");
                    return;
                }
            }

            var convertedValue = RomanArabicConverter.ToArabicNumber(localRoman);
            var commodityValue = RomanToGalacticMapper.GetCommodityValue(commodity);
            var totalValue = commodityValue * convertedValue;
            OutputWriter2(inputArray, totalValue);
        }

        private static void CalculateCommodityPrice(IReadOnlyList<string> galacticRoman)
        {
            var localRoman = string.Empty;
            var numberOfCredits = galacticRoman[1].Split(' ');

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
                    var convertedValue = RomanArabicConverter.ToArabicNumber(localRoman);
                    var credits = numberOfCredits[0];
                    if(decimal.TryParse(credits, out var totalValue))
                        SetCommodityPrice(convertedValue, galacticNames.Last(), totalValue);
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

        private static void OutputWriter(IReadOnlyList<string> inputArray, decimal convertedValue)
        {
            Console.WriteLine(convertedValue >= 0
                ? $"{inputArray[1]} is {convertedValue}"
                : $"{inputArray[1]} is an invalid value");
        }

        private static void OutputWriter2(IReadOnlyList<string> inputArray, decimal totalValue)
        {
            Console.WriteLine(totalValue >= 0
                ? $"{inputArray[1]} is {totalValue} Credits"
                : $"{inputArray[1]} is an invalid value");
        }
    }
}