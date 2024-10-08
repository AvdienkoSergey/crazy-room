namespace ConsoleApp.CrazyRoom.Hero;

using ConsoleApp.CrazyRoom.Position;

public class Hero(char symbol, Position position) : IHero
{
    
    private readonly char _symbol = symbol;
    private readonly Position _position = position;
    
    public char GetAvatar()
    {
        return _symbol;
    }

    public void MoveLeft(sbyte min)
    {
        if (_position.X > min) _position.SetX((sbyte)(_position.X - 1));
    }

    public void MoveRight(sbyte max)
    {
        if (_position.X < max) _position.SetX((sbyte)(_position.X + 1));
    }

    public void MoveUp(sbyte min)
    {
        if (_position.Y > min) _position.SetY((sbyte)(_position.Y - 1));
    }

    public void MoveDown(sbyte max)
    {
        if (_position.Y < max) _position.SetY((sbyte)(_position.Y + 1));
    }
}