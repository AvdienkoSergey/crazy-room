using Microsoft.Extensions.DependencyInjection;
using ConsoleApp.CrazyRoom;
using ConsoleApp.CrazyRoom.Interfaces;
using ConsoleApp.CrazyRoom.Services;
using ConsoleApp.CrazyRoom.Models;
using ConsoleApp.CrazyRoom.Models.Things;

var serviceCollection = new ServiceCollection();
serviceCollection.AddSingleton<IInteractionService, MineInteractionService>();
serviceCollection.AddSingleton<IRenderService, RenderService>();
serviceCollection.AddSingleton<IStatusService, StatusService>();
serviceCollection.AddSingleton<IEventService, EventService>();
serviceCollection.AddSingleton<IEventLoggerService, EventLoggerService>();
serviceCollection.AddSingleton<IGame, Game>();

var serviceProvider = serviceCollection.BuildServiceProvider();

var gameDesigner = new RoomDesigner(
    new Room(
        20,
        10,
        new Hero('H', new Position()),
        [
            new Mine('Y', new Position(), 2),
            new Mine('M', new Position(), 1),
            new Mine('O', new Position(), 1),
        ]
    )
);

var game = serviceProvider.GetService<IGame>();
game?.Start(gameDesigner.GetRoom());
