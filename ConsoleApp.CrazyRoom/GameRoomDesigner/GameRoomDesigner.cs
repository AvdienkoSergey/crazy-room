namespace ConsoleApp.CrazyRoom.GameRoomDesigner;

using GameRoom;
using Position;
using Game;

public class GameRoomDesigner
{
    private readonly IGameRoom _gameRoom;
    private readonly IPosition[] _usingPositions;
    private int _currentUsingPositionIndex;

    public GameRoomDesigner(IGameRoom gameRoom)
    {
        _gameRoom = gameRoom;
        _usingPositions = new IPosition[gameRoom.GetThingsListInRoom().Length];
        _currentUsingPositionIndex = 0;

        PlaceThingsInRoom();
        PlaceHeroToRoom();
    }

    private void PlaceHeroToRoom()
    {
        var hero = _gameRoom.GetHero();
        var randomPosition = GetRandomPosition();
        hero.SetPosition(randomPosition);
    }
    
    private void PlaceThingsInRoom()
    {
        foreach (var thing in _gameRoom.GetThingsListInRoom())
        {
            var randomPosition = GetRandomPosition();
            thing.SetPosition(randomPosition);
        }
    }
    
    private IPosition GetRandomPosition()
    {
        var random = new Random();
        IPosition randomPosition;
        
        do {
            var randomX = (sbyte)random.Next(0, _gameRoom.GetWidth());
            var randomY = (sbyte)random.Next(0, _gameRoom.GetHeight());
            randomPosition = new Position(randomX, randomY);
        }
        while (_usingPositions.Contains(randomPosition));
        
        if (_currentUsingPositionIndex >= _usingPositions.Length)
        {
            return randomPosition;
        }
        
        _usingPositions[_currentUsingPositionIndex] = randomPosition;
        _currentUsingPositionIndex++;
        
        return randomPosition;
    }
    
    public Game GetGame()
    {
        var game = new Game(_gameRoom);
        return game;
    }
}