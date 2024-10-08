namespace ConsoleApp.CrazyRoom.Position;

public interface IPosition
{
    /// <summary>
    /// Текущее значение X
    /// </summary>
    int X { get; }
    
    /// <summary>
    /// Текущее значение Y
    /// </summary>
    int Y { get; }
    
    /// <summary>
    /// Установка нового значения для X
    /// </summary>
    /// <param name="value"> Новое значение для X </param>
    public void SetX(sbyte value);
    
    /// <summary>
    /// Установка нового значения для Y
    /// </summary>
    /// <param name="value"> Новое значение для Y </param>
    public void SetY(sbyte value);
    
}