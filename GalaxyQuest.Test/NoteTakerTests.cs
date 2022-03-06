using GalaxyQuest.Interfaces;
using GalaxyQuest.Models;
using NSubstitute;
using Xunit;

namespace GalaxyQuest.Test;

public class NoteTakerTests
{
    private readonly INoteTaker _sut;
    private readonly ICurrencyConverter _currencyConverter;
    private readonly IMessageWriter _messageWriter;
    private readonly INumberMapper _numberMapper;

    public NoteTakerTests()
    {
        _currencyConverter = Substitute.For<ICurrencyConverter>();
        _messageWriter = Substitute.For<IMessageWriter>();
        _numberMapper = Substitute.For<INumberMapper>();
        _sut = new NoteTaker(_currencyConverter, _numberMapper, _messageWriter);
    }

    [Fact]
    public void ProcessUserInput_WithValidInput_CallsMapMethod()
    {
        //Arrange
        const string input = "glob is I";

        //Act
        _sut.ProcessUserInput(input);

        //Assert
        _numberMapper.Received().MapGalacticToRoman(Arg.Any<string>(), Arg.Any<string>());
    }

    [Theory]
    [InlineData("glob ix I")]
    [InlineData("glob isI")]
    [InlineData("globis I")]
    public void ProcessUserInput_WithInvalidInput_CallsWriteMessageMethod(string input)
    {
        //Act
        _sut.ProcessUserInput(input);

        //Assert
        _messageWriter.Received().WriteMessage(Arg.Any<string>());
    }

    [Fact]
    public void ProcessUserInput_WithValidInput_CallsGetCommodityPrice()
    {
        //Arrange
        const string input = "how many Credits is glob prok Silver?";
        _currencyConverter.GetCommodityData(Arg.Any<string>())
            .Returns(new ReturnDTO {Number = 10, Message = string.Empty});

        //Act
        _sut.ProcessUserInput(input);

        //Assert
        _currencyConverter.Received().GetCommodityData(Arg.Any<string>());
    }

    [Fact]
    public void ProcessUserInput_WithValidInput_CallsCalculateCommodityPrice()
    {
        //Arrange
        const string input = "glob prok Silver is 34 credits";

        //Act
        _sut.ProcessUserInput(input);

        //Assert
        _currencyConverter.Received().CalculateCommodityPrice(Arg.Any<string[]>());
    }
    
    [Fact]
    public void ProcessUserInput_WithValidInput_CallsCalculateArabicValue()
    {
        //Arrange
        const string input = "how much is pish tegj glob glob";
        _currencyConverter.CalculateArabicValue(Arg.Any<string>())
            .Returns(new ReturnDTO {Number = 10, Message = string.Empty});

        //Act
        _sut.ProcessUserInput(input);

        //Assert
        _currencyConverter.Received().CalculateArabicValue(Arg.Any<string>());
        _messageWriter.Received().WriteMessage(Arg.Any<string>());
    }

    [Fact]
    public void ProcessUserInput_WithInvalidInput_CallsWriteMessage()
    {
        //Arrange
        const string input = "how much is pish tegj glob glob";
        _currencyConverter.CalculateArabicValue(Arg.Any<string>())
            .Returns(new ReturnDTO { Number = 10, Message = "Invalid value..." });

        //Act
        _sut.ProcessUserInput(input);

        //Assert
        _currencyConverter.Received().CalculateArabicValue(Arg.Any<string>());
        _messageWriter.Received().WriteMessage(Arg.Any<string>());
    }
    
    [Fact]
    public void GetUserInput_WithValidInput_CallsCalculateArabicValue()
    {
        //Arrange
        const string input = "how much is pish tegj glob glob";
        _currencyConverter.CalculateArabicValue(Arg.Any<string>())
            .Returns(new ReturnDTO {Number = 10, Message = string.Empty});

        //Act
        _sut.ProcessUserInput(input);

        //Assert
        _currencyConverter.Received().CalculateArabicValue(Arg.Any<string>());
        _messageWriter.Received().WriteMessage(Arg.Any<string>());
    }
}