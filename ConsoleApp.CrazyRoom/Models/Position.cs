namespace ConsoleApp.CrazyRoom.Models;

using Interfaces;

public class Position : IPosition
{
    private sbyte _x = 0;
    private sbyte _y = 0;

    public Position()
    {}

    public Position(sbyte x, sbyte y)
    {
        _x = x;
        _y = y;
    }

    public int X => _x;
    public int Y => _y;

    public void SetX(sbyte value)
    {
        _x = value;
    }
    public void SetY(sbyte value)
    {
        _y = value;
    }
}