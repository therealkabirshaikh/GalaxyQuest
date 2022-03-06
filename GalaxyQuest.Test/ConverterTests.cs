using System.Collections.Generic;
using GalaxyQuest.Interfaces;
using NSubstitute;
using Xunit;

namespace GalaxyQuest.Test
{
    public class ConverterTests
    {
        private readonly GalaxyQuestCurrencyConverter _sut;
        private readonly INumberMapper _numberMapper;
        private readonly IMessageWriter _messageWriter;

        public ConverterTests()
        {
            _numberMapper = Substitute.For<INumberMapper>();
            _messageWriter = Substitute.For<IMessageWriter>();
            _sut = new GalaxyQuestCurrencyConverter(_numberMapper, _messageWriter);
        }

        [Fact]
        public void CalculateArabicValue_GivenValidInput_ReturnsCorrectValue()
        {
            //Arrange
            const string input = "pish tegj glob glob";
            var map = new Dictionary<string, string>
            {
                {"pish", "X"},
                {"tegj", "L"},
                {"glob", "I"},
            };
            _numberMapper.GetMap().Returns(map);

            //Act
            var dto = _sut.CalculateArabicValue(input);

            //Assert
            Assert.Equal(42, dto.Number);
            Assert.Equal(string.Empty, dto.Message);
        }
        
        [Fact]
        public void CalculateArabicValue_GivenInvalidInput_ReturnsErrorMessage()
        {
            //Arrange
            const string input = "pish posh";
            var map = new Dictionary<string, string>
            {
                {"pish", "X"},
                {"tegj", "L"},
                {"glob", "I"},
            };
            _numberMapper.GetMap().Returns(map);

            //Act
            var dto = _sut.CalculateArabicValue(input);

            //Assert
            Assert.Equal("I have no idea what you are talking about", dto.Message);
        }
    }
}