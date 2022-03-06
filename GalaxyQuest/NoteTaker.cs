using GalaxyQuest.Interfaces;

namespace GalaxyQuest
{
    public class NoteTaker : INoteTaker
    {
        private readonly ICurrencyConverter _currencyConverter;
        private readonly INumberMapper _numberMapper;
        private readonly IMessageWriter _messageWriter;
        private bool Terminate { get; set; }

        public NoteTaker(ICurrencyConverter currencyConverter, INumberMapper numberMapper, IMessageWriter messageWriter)
        {
            _currencyConverter = currencyConverter;
            _numberMapper = numberMapper;
            _messageWriter = messageWriter;
        }

        public void GalaxyQuestNotes()
        {
            _messageWriter.WriteMessage("Enter notes...");
            
            while (!Terminate)
            {
                var input = Console.ReadLine();
                if (input != null && input.Trim().Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    Terminate = true;
                    continue;
                }
                var userInput = GetUserInput(input);
                ProcessUserInput(userInput);
            }
            Environment.Exit(0);
        }

        private static string? GetUserInput(string? userInput)
        {
            if (userInput == null) 
                return userInput;
            
            var startIndex = userInput.LastIndexOf('?');
            if (startIndex != -1)
            {
                userInput = userInput.Remove(startIndex);
            }
            
            userInput = userInput.Trim();

            return userInput;
        }

        public void ProcessUserInput(string? userInput)
        {
            if (userInput != null && userInput.Contains(" is ", StringComparison.OrdinalIgnoreCase))
            {
                var userInputArray = userInput.Split(" is ");
                var questionText = userInputArray[0];
                var commodityData = userInputArray[1];
                if (questionText.Equals("how much", StringComparison.OrdinalIgnoreCase))
                {
                    var commodityObject = _currencyConverter.CalculateArabicValue(commodityData);
                    if (commodityObject.Message != string.Empty)
                    {
                        _messageWriter.WriteMessage(commodityObject.Message);
                    }
                    else
                    {
                        _messageWriter.WriteMessage(commodityObject.Number >= 0
                            ? $"{commodityData} is {commodityObject.Number}"
                            : $"{commodityData} is an invalid value");
                    }
                }
                else if (questionText.StartsWith("how many", StringComparison.OrdinalIgnoreCase))
                {
                    var commodity = _currencyConverter.GetCommodityData(commodityData);
                    _messageWriter.WriteMessage(commodity.Number >= 0
                        ? $"{commodityData} is {commodity.Number} Credits"
                        : $"{commodityData} is an invalid value");
                }
                else
                {
                    if (commodityData.EndsWith("credits", StringComparison.OrdinalIgnoreCase))
                    {
                        _currencyConverter.CalculateCommodityPrice(userInputArray);
                    }
                    else
                    {
                        _numberMapper.Map(questionText, commodityData);
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