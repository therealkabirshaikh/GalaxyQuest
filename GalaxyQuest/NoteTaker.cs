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
                var userInput = UserInputValidator.GetUserInput(input);
                ProcessUserInput(userInput);
            }
            Environment.Exit(0);
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
                    _messageWriter.WriteMessage(commodityObject.Message != string.Empty
                        ? commodityObject.Message
                        : $"{commodityData} is {commodityObject.Number}");
                }
                else if (questionText.StartsWith("how many", StringComparison.OrdinalIgnoreCase))
                {
                    var commodity = _currencyConverter.GetCommodityData(commodityData);
                    _messageWriter.WriteMessage($"{commodityData} is {commodity.Number} Credits");
                }
                else
                {
                    if (commodityData.EndsWith("credits", StringComparison.OrdinalIgnoreCase))
                    {
                        _currencyConverter.CalculateCommodityPrice(userInputArray);
                    }
                    else
                    {
                        _numberMapper.MapGalacticToRoman(questionText, commodityData);
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