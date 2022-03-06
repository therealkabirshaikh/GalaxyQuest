using GalaxyQuest.Interfaces;

namespace GalaxyQuest;

public class ConsoleWriter : IMessageWriter
{
    public void WriteMessage(string? message)
    {
        Console.WriteLine(message);
    }
}