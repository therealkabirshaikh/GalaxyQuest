using GalaxyQuest;
using GalaxyQuest.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
        services.AddSingleton<INumberMapper, NumberMapper>()
                .AddSingleton<ICurrencyConverter, GalaxyQuestCurrencyConverter>()
                .AddSingleton<INoteTaker, NoteTaker>()
                .AddTransient<IMessageWriter, ConsoleWriter>()
        )
    .Build();

var noteTaker = host.Services.GetService<INoteTaker>();
noteTaker?.GalaxyQuestNotes();

await host.RunAsync();