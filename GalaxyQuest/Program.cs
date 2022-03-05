using System;
using System.Linq;
using System.Collections.Generic;

namespace GalaxyQuest
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //1 Silver = 17
            //1 Gold = 14450
            //1 Iron = 
            var input = string.Empty;
            Console.WriteLine("Enter notes");
            while (input != "exit")
            {
                input = Console.ReadLine();
                if (input.Contains("is"))
                {
                    string[] galacticRoman = input.Split(" is ");
                    if (galacticRoman[0] == "how much") //TODO: Validate input, null check, etc.
                    {
                        var localRoman = string.Empty;

                        var galacticNames = galacticRoman[1].Split(' ');
                        foreach (var g in galacticNames)
                        {
                            Dictionary<string, string> valueMap = RomanToGalacticMapper.GetMap();
                            localRoman += valueMap[g];
                        }
                        var convertedValue = Roman.From(localRoman);
                        Console.WriteLine(convertedValue);
                    }
                    else if (galacticRoman[0] == "how many")
                    {
                        var localRoman = string.Empty;
                        //convert galactic to roman
                        for (int i = 1; i < galacticRoman.Length; i++)
                        {
                            Dictionary<string, string> valueMap = RomanToGalacticMapper.GetMap();
                            localRoman += valueMap[galacticRoman[i]];
                        }
                    }
                    else //assuming value entry here
                    {
                        //glob glob Silver is 34 Credits
                        //galacticRoman[0] = glob glob Silver
                        //galacticRoman[1] = 34 credits
                        if (galacticRoman[1].EndsWith("Credits"))
                        {
                            var localRoman = string.Empty;
                            var fred = galacticRoman[1].Split(' ');

                            var galacticNames = galacticRoman[1].Split(' ');
                            foreach (var g in galacticNames)
                            {
                                Dictionary<string, string> valueMap1 = RomanToGalacticMapper.GetMap();
                                localRoman += valueMap1[g];
                            }
                            var convertedValue = Roman.From(localRoman);

                            //Calculate unit price
                        }

                        RomanToGalacticMapper.Map(galacticRoman[0], galacticRoman[1]);
                        Dictionary<string, string> valueMap = RomanToGalacticMapper.GetMap();
                        foreach (var item in valueMap)
                        {
                            Console.WriteLine(item);
                        }
                    }

                }
            }
        }
    }
}
