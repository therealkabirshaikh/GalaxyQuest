using GalaxyQuest.Interfaces;
using Xunit;

namespace GalaxyQuest.Test;

public class NumberMapperTests
{
    private readonly INumberMapper _sut;

    public NumberMapperTests()
    {
        _sut = new NumberMapper();
    }

    [Fact]
    public void SetCommodityPrice_WhenCalled_AddsExpectedValueToPrivateDataStore()
    {
        //Arrange
        const string commodityName = "iron";

        //Act
        _sut.SetCommodityPrice(commodityName, 4, 40);
        var price = _sut.GetCommodityPrice(commodityName);

        //Assert
        Assert.Equal(10, price);
    }

    [Fact]
    public void SetCommodityPrice_WhenSentDuplicateCommodity_ReplacesExistingValue()
    {
        //Arrange
        const string commodityName = "iron";

        //Act
        _sut.SetCommodityPrice(commodityName, 4, 40);
        _sut.SetCommodityPrice(commodityName, 8, 40);
        var price = _sut.GetCommodityPrice(commodityName);

        //Assert
        Assert.Equal(5, price);
    }

    [Fact]
    public void MapGalacticToRoman_WhenCalled_AddsExpectedValueToPrivateDataStore()
    {
        //Arrange
        const string galactic = "glob";
        const string roman = "i";

        //Act
        var added = _sut.MapGalacticToRoman(galactic, roman);
        var map = _sut.GetGalacticToRomanMap();
        var value = map["glob"];

        //Assert
        Assert.True(added);
        Assert.Equal(roman, value);
    }
    
    [Fact]
    public void MapGalacticToRoman_WhenCalledWithInvalidRomanNumeral_ReturnsFalse()
    {
        //Arrange
        const string galactic = "glob";
        const string roman = "W";

        //Act
        var added = _sut.MapGalacticToRoman(galactic, roman);
        var map = _sut.GetGalacticToRomanMap();
        var found =  map.TryGetValue("glob", out var value);

        //Assert
        Assert.False(added);
        Assert.False(found);
    }
    
    [Fact]
    public void MapGalacticToRoman_WhenSentDuplicateValue_ReplacesExistingValue()
    {
        //Arrange
        const string galactic = "glob";
        const string roman = "i";

        //Act
        var added = _sut.MapGalacticToRoman(galactic, roman);
        added = _sut.MapGalacticToRoman(galactic, "x");
        var map = _sut.GetGalacticToRomanMap();
        var value = map["glob"];

        //Assert
        Assert.True(added);
        Assert.Equal("x", value);
    }
}