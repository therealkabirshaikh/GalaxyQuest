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
    public void Map_WhenCalled_AddsExpectedValueToPrivateDataStore()
    {
        //Arrange
        const string galactic = "glob";
        const string roman = "I";

        //Act
        _sut.Map(galactic, roman);
        var map = _sut.GetMap();
        var value = map["glob"];

        //Assert
        Assert.Equal("I", value);
    }
    
    [Fact]
    public void Map_WhenSentDuplicateValue_ReplacesExistingValue()
    {
        //Arrange
        const string galactic = "glob";
        const string roman = "I";

        //Act
        _sut.Map(galactic, roman);
        _sut.Map(galactic, "X");
        var map = _sut.GetMap();
        var value = map["glob"];

        //Assert
        Assert.Equal("X", value);
    }
}