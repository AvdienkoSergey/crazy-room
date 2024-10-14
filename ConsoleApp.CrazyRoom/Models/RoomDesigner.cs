namespace ConsoleApp.CrazyRoom.Models;

using Interfaces;

public class RoomDesigner : IRoomDesigner
{
    private readonly IRoom _room;
    private readonly IPosition[] _usingPositions;
    private int _currentUsingPositionIndex;

    public RoomDesigner(IRoom room)
    {
        _room = room;
        _usingPositions = new IPosition[room.GetThingsListInRoom().Length];
        _currentUsingPositionIndex = 0;

        PlaceThingsInRoom();
        PlaceHeroToRoom();
    }

    private void PlaceHeroToRoom()
    {
        var hero = _room.GetHero();
        var randomPosition = GetRandomPosition();
        hero.SetPosition(randomPosition);
    }
    
    private void PlaceThingsInRoom()
    {
        foreach (var thing in _room.GetThingsListInRoom())
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
            var randomX = (sbyte)random.Next(0, _room.GetWidth());
            var randomY = (sbyte)random.Next(0, _room.GetHeight());
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
    
    public IRoom GetRoom()
    {
        return _room; 
    }
}