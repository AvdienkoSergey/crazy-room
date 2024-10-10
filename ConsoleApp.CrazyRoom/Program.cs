using Microsoft.Extensions.DependencyInjection;
using ConsoleApp.CrazyRoom.GameRoom;
using ConsoleApp.CrazyRoom.GameRoomDesigner;
using ConsoleApp.CrazyRoom.Hero;
using ConsoleApp.CrazyRoom.Position;
using ConsoleApp.CrazyRoom.Things;

var gameDesigner = new GameRoomDesigner(
    new GameRoom(
        10,
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