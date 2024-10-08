namespace ConsoleApp.CrazyRoom.Position;

public class Position(sbyte x, sbyte y) : IPosition
{
    private sbyte _x;
    private sbyte _y;

    public int X => _x;
    public int Y => _y;
    
    public void SetX(sbyte x) => _x = x;
    public void SetY(sbyte y) => _y = y;
}