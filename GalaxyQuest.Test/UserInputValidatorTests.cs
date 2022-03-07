using Xunit;

namespace GalaxyQuest.Test;

public class UserInputValidatorTests
{
    [Fact]
    public void GetUserInput_WhenValidInputSupplied_ReturnsSameInput()
    {
        //Arrange
        const string input = "glob is I";
        
        //Act
        var actual = UserInputValidator.GetUserInput(input);
        
        //Assert
        Assert.Equal("glob is i", actual);
    }
    
    [Fact]
    public void GetUserInput_WhenNullInputSupplied_ReturnsSameInput()
    {
        //Arrange
        const string input = null;
        
        //Act
        var actual = UserInputValidator.GetUserInput(input);
        
        //Assert
        Assert.Null(actual);
    }
    
    [Fact]
    public void GetUserInput_WhenInputEndsWithQuestionMarkSupplied_ReturnsInputWithoutQuestionMark()
    {
        //Arrange
        const string input = "how much is pish glob?";
        
        //Act
        var actual = UserInputValidator.GetUserInput(input);
        
        //Assert
        Assert.Equal("how much is pish glob", actual);
    }
    
    [Fact]
    public void GetUserInput_WhenInputWithLeadingOrTrailingSpacesSupplied_ReturnsTrimmedInput()
    {
        //Arrange
        const string input = " how much is pish glob? ";
        
        //Act
        var actual = UserInputValidator.GetUserInput(input);
        
        //Assert
        Assert.Equal("how much is pish glob", actual);
    }
}