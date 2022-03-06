using GalaxyQuest.Interfaces;

namespace GalaxyQuest
{
    public class NoteTaker : INoteTaker
    {
        private readonly ICurrencyConverter _currencyConverter;
        private readonly INumberMapper _numberMapper;
        private readonly IMessageWriter _messageWriter;

        public NoteTaker(ICurrencyConverter currencyConverter, INumberMapper numberMapper, IMessageWriter messageWriter)
        {
            _currencyConverter = currencyConverter;
            _numberMapper = numberMapper;
            _messageWriter = messageWriter;
        }

        public void GalaxyQuestNotes()
        {
            _messageWriter.WriteMessage("Enter notes...");
            
            while (true)
            {
                var userInput = Console.ReadLine();
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
                        var arabicNumber = _currencyConverter.CalculateArabicValue(userInputArray[1]);
                        if (arabicNumber.Message != string.Empty)
                        {
                            _messageWriter.WriteMessage(arabicNumber.Message);
                        }
                        else
                        {
                            _messageWriter.WriteMessage(arabicNumber.Number >= 0
                                ? $"{userInputArray[1]} is {arabicNumber.Number}"
                                : $"{userInputArray[1]} is an invalid value");
                        }
                    }
                    else if (userInputArray[0].StartsWith("how many", StringComparison.OrdinalIgnoreCase))
                    {
                        var commodity = _currencyConverter.GetCommodityPrice(userInputArray[1]);
                        _messageWriter.WriteMessage(commodity.Number >= 0
                            ? $"{userInputArray[1]} is {commodity.Number} Credits"
                            : $"{userInputArray[1]} is an invalid value");
                    }
                    else
                    {
                        if (userInputArray[1].EndsWith("credits", StringComparison.OrdinalIgnoreCase))
                        {
                            _currencyConverter.CalculateCommodityPrice(userInputArray);
                        }
                        else
                        {
                            _numberMapper.Map(userInputArray[0], userInputArray[1]);
                        }
                    }
                }
                else
                {
                    _messageWriter.WriteMessage("I have no idea what you are talking about");
                }
            }
        }
    }
}