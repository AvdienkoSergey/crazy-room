namespace ConsoleApp.CrazyRoom.Hero;

using Position;

public class Hero(char symbol, IPosition position) : IHero, IGameCharacter
{
    
    private readonly char _symbol = symbol;
    private IPosition _position = position;
    private int _health = 100;
    
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

    public void TakeDamage(int damage)
    {
        _health -= damage;
    }
    
    public void SetPosition(IPosition position)
    {
        _position = position;
    }

    public IPosition GetPosition()
    {
        return _position;
    }

    public int GetHealth()
    {
        return _health;
    }
}