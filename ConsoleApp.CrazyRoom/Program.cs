using Microsoft.Extensions.DependencyInjection;
using ConsoleApp.CrazyRoom.GameRoom;
using ConsoleApp.CrazyRoom.GameRoomDesigner;
using ConsoleApp.CrazyRoom.Hero;
using ConsoleApp.CrazyRoom.Position;
using ConsoleApp.CrazyRoom.Things;

var gameDesigner = new GameRoomDesigner(
    new GameRoom(
        20,
        10,
        new Hero('H', new Position()),
        [
            new Mine('M', new Position(), 1)
        ]
    )
);
var game = gameDesigner.GetGame();
game.Start();