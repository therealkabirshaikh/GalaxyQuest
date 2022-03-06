using System;

namespace GalaxyQuest
{
    internal class NoteTaker
    {
        public static void GalaxyQuestNotes()
        {
            var userInput = string.Empty;
            Console.WriteLine("Enter notes...");
            while (true)
            {
                userInput = Console.ReadLine();
                if (userInput.Equals("exit", StringComparison.OrdinalIgnoreCase))
                    Environment.Exit(0);

                var startIndex = userInput.LastIndexOf('?');
                if (startIndex != -1)
                {
                    userInput = userInput.Remove(startIndex);
                }

                userInput = userInput.Trim();

                if (userInput.Contains(" is ", StringComparison.OrdinalIgnoreCase))
                {
                    var userInputArray = userInput.Split(" is ");
                    if (userInputArray[0].Equals("how much", StringComparison.OrdinalIgnoreCase))
                    {
                        var arabicNumber = GalaxyQuestCurrencyConverter.CalculateArabicValue(userInputArray);
                        if (arabicNumber.Message != string.Empty)
                        {
                            Console.WriteLine(arabicNumber.Message);
                        }
                        else
                        {
                            Console.WriteLine(arabicNumber.Number >= 0
                                ? $"{userInputArray[1]} is {arabicNumber.Number}"
                                : $"{userInputArray[1]} is an invalid value");
                        }
                    }
                    else if (userInputArray[0].StartsWith("how many", StringComparison.OrdinalIgnoreCase))
                    {
                        var commodity = GalaxyQuestCurrencyConverter.GetCommodityValue(userInputArray);
                        Console.WriteLine(commodity.Number >= 0
                            ? $"{userInputArray[1]} is {commodity.Number} Credits"
                            : $"{userInputArray[1]} is an invalid value");
                    }
                    else
                    {
                        if (userInputArray[1].EndsWith("credits", StringComparison.OrdinalIgnoreCase))
                        {
                            GalaxyQuestCurrencyConverter.CalculateCommodityPrice(userInputArray);
                        }
                        else
                        {
                            RomanToGalacticMapper.Map(userInputArray[0], userInputArray[1]);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("I have no idea what you are talking about");
                }
            }
        }
    }
}