namespace GalaxyQuest;

public static class UserInputValidator
{
    public static string? GetUserInput(string? userInput)
    {
        if (userInput == null) 
            return userInput;
            
        var startIndex = userInput.LastIndexOf('?');
        if (startIndex != -1)
        {
            userInput = userInput.Remove(startIndex);
        }
            
        userInput = userInput.Trim();

        return userInput;
    }
}