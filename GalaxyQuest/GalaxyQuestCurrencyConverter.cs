using GalaxyQuest.Interfaces;
using GalaxyQuest.Models;

namespace GalaxyQuest
{
    public class GalaxyQuestCurrencyConverter : ICurrencyConverter
    {
        private readonly INumberMapper _numberMapper;
        private readonly IMessageWriter _messageWriter;

        public GalaxyQuestCurrencyConverter(INumberMapper numberMapper, IMessageWriter messageWriter)
        {
            _numberMapper = numberMapper;
            _messageWriter = messageWriter;
        }

        public ReturnDTO CalculateArabicValue(string input)
        {
            var localRoman = string.Empty;
            var message = string.Empty;
            var galacticNames = input.Split(' ');

            foreach (var name in galacticNames)
            {
                if (name.Equals(string.Empty))
                    continue;

                var map = _numberMapper.GetMap();

                if (map.TryGetValue(name, out _))
                    localRoman += map[name];
                else
                {
                    message = "I have no idea what you are talking about";
                }
            }

            var convertedValue = RomanArabicConverter.ToArabicNumber(localRoman);

            return new ReturnDTO {Message = message, Number = convertedValue};
        }

        public ReturnDTO GetCommodityValue(IReadOnlyList<string> inputArray)
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

                var map = _numberMapper.GetMap();
                if (map.TryGetValue(name, out _))
                    localRoman += map[name];
                else
                {
                    message = "I have no idea what you are talking about";
                }
            }

            var convertedValue = RomanArabicConverter.ToArabicNumber(localRoman);
            var commodityValue = _numberMapper.GetCommodityValue(commodity);
            var totalValue = commodityValue * convertedValue;

            return new ReturnDTO {Number = totalValue, Message = message};
        }

        public void CalculateCommodityPrice(IReadOnlyList<string> galacticRoman)
        {
            var localRoman = string.Empty;
            var numberOfCredits = galacticRoman[1].Split(' ');
            var galacticNames = galacticRoman[0].Split(' ');
            foreach (var name in galacticNames)
            {
                Dictionary<string, string> map = _numberMapper.GetMap();
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
                        _messageWriter.WriteMessage("I have no idea what you are talking about");
                    }
                }
            }
        }

        private void SetCommodityPrice(decimal convertedValue, string g, decimal totalValue)
        {
            _numberMapper.SetCommodityPrice(convertedValue, g, totalValue);
        }
    }
}