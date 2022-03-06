using GalaxyQuest.Converters;
using Xunit;

namespace GalaxyQuest.Test
{
    public class RomanToArabicTest
    {
        [Theory]
        [InlineData("I",1)]
        [InlineData("II",2)]
        [InlineData("III",3)]
        [InlineData("IV",4)]
        [InlineData("V",5)]
        [InlineData("IX",9)]
        [InlineData("X",10)]
        [InlineData("XLIX",49)]
        [InlineData("L",50)]
        [InlineData("C",100)]
        [InlineData("CD",400)]
        [InlineData("D",500)]
        [InlineData("CM",900)]
        [InlineData("MMMMMMMMMMMCMLXXXIV",11984)]
        public void ToArabicNumber_ValidValue_ReturnsCorrectNumber(string romanNumeral, int expectedValue)
        {
            Assert.Equal(expectedValue, RomanArabicConverter.ToArabicNumber(romanNumeral));
        }

        [Fact]
        public void ToArabicNumber_InvalidValue_ReturnsNegativeOne()
        {
            Assert.Equal(-1, RomanArabicConverter.ToArabicNumber("IVL"));
        }

    }
}
