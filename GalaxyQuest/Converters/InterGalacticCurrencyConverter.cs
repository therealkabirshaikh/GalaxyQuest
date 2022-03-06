using GalaxyQuest.Interfaces;
using GalaxyQuest.Models;

namespace GalaxyQuest.Converters
{
    public class InterGalacticCurrencyConverter : ICurrencyConverter
    {
        private readonly INumberMapper _numberMapper;
        private readonly IMessageWriter _messageWriter;

        public InterGalacticCurrencyConverter(INumberMapper numberMapper, IMessageWriter messageWriter)
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

                var map = _numberMapper.GetGalacticToRomanMap();

                if (map.TryGetValue(name, out _))
                    localRoman += map[name];
                else
                {
                    message = Constants.ErrorMessage;
                }
            }

            var convertedValue = RomanArabicConverter.ToArabicNumber(localRoman);

            return new ReturnDTO {Message = message, Number = convertedValue};
        }

        public ReturnDTO GetCommodityData(string inputArray)
        {
            var localRoman = string.Empty;
            var message = string.Empty;
            var galacticValueAndCommodity = inputArray.Split(' ');
            var commodity = galacticValueAndCommodity.TakeLast(1).First();
            Array.Resize(ref galacticValueAndCommodity, galacticValueAndCommodity.Length - 1);

            foreach (var name in galacticValueAndCommodity)
            {
                if (name.Equals(string.Empty))
                    continue;

                var map = _numberMapper.GetGalacticToRomanMap();
                if (map.TryGetValue(name, out _))
                    localRoman += map[name];
                else
                {
                    message = Constants.ErrorMessage;
                }
            }

            var commodityQuantity = RomanArabicConverter.ToArabicNumber(localRoman);
            var commodityValue = _numberMapper.GetCommodityPrice(commodity);
            var totalValue = commodityValue * commodityQuantity;

            return new ReturnDTO {Number = totalValue, Message = message};
        }

        public void CalculateCommodityPrice(IReadOnlyList<string> galacticRoman)
        {
            var localRoman = string.Empty;
            var numberOfCredits = galacticRoman[1].Split(' ');
            var galacticNames = galacticRoman[0].Split(' ');
            foreach (var name in galacticNames)
            {
                Dictionary<string, string> map = _numberMapper.GetGalacticToRomanMap();
                if (map.ContainsKey(name))
                {
                    localRoman += map[name];
                }
                else
                {
                    var convertedValue = RomanArabicConverter.ToArabicNumber(localRoman);
                    var credits = numberOfCredits[0];
                    if (decimal.TryParse(credits, out var totalValue))
                        _numberMapper.SetCommodityPrice(galacticNames.Last(),convertedValue, totalValue);
                    else
                    {
                        _messageWriter.WriteMessage(Constants.ErrorMessage);
                    }
                }
            }
        }
    }
}