using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace GalaxyQuest
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var noteTaker = new NoteTaker();
            noteTaker.GalaxyQuestNotes();
        }
    }
}