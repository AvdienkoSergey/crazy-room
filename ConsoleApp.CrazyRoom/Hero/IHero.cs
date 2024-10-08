namespace ConsoleApp.CrazyRoom.Hero;

public interface IHero
{
    /// <summary>
    /// Отображение героя в игровой комнате
    /// </summary>
    /// <returns> Возвращает символ, которым будет обозначен игрок в игровой комнате </returns>
    public char GetAvatar();
    
    /// <summary>
    /// Отрицательное движение по оси X
    /// </summary>
    /// <param name="min"> Значение, ниже которого игрок не может двигаться по оси X</param>
    public void MoveLeft(sbyte min);
    
    /// <summary>
    /// Положительное движение по оси X
    /// </summary>
    /// <param name="max"> Значение, выше которого игрок не может двигаться по оси X</param>
    public void MoveRight(sbyte max);
    
    /// <summary>
    /// Отрицательное движение по оси Y
    /// </summary>
    /// <param name="min"> Значение, ниже которого игрок не может двигаться по оси Y</param>
    public void MoveUp(sbyte min);
    
    /// <summary>
    /// Положительное движение по оси Y
    /// </summary>
    /// <param name="max"> Значение, выше которого игрок не может двигаться по оси Y</param>
    public void MoveDown(sbyte max);
}