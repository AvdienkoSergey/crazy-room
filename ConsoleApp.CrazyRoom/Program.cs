using Microsoft.Extensions.DependencyInjection;
using ConsoleApp.CrazyRoom;
using ConsoleApp.CrazyRoom.Interfaces;
using ConsoleApp.CrazyRoom.Things;

var serviceCollection = new ServiceCollection();
/*
serviceCollection.AddSingleton<ICharacter, Hero>(provider => new Hero('H', new Position()));
serviceCollection.AddSingleton<ICharacter[]>(provider => [
    new Mine('Y', new Position(), 2),
    new Mine('M', new Position(), 1),
    new Mine('O', new Position(), 1),
]);
serviceCollection.AddSingleton<IRoom, Room>(provider =>
{
    var hero = provider.GetRequiredService<Hero>();
    var gameObjects = provider.GetRequiredService<Thing[]>();
    return new Room(10, 10, hero, gameObjects);
});
var serviceProvider = serviceCollection.BuildServiceProvider();
var gameDesigner = serviceProvider.GetRequiredService<RoomDesigner>();
var game = gameDesigner.GetGame();
game.Start();
*/

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
var game = gameDesigner.GetGame();
game.Start();
