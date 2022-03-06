using NSubstitute;
using Xunit;

namespace GalaxyQuest.Test
{
    public class ConverterTests
    {
        public ConverterTests()
        {
            //Substitute.For()
        }
        
        [Fact]
        public void CalculateArabicValue_GivenValidInput_ReturnsCorrectValue()
        {
            //Arrange
            const string input = "pish tegj glob glob";
            
            //Act
            var dto = GalaxyQuestCurrencyConverter.CalculateArabicValue(input);
            
            //Assert
            Assert.Equal(1, dto.Number);
        }
    }
}