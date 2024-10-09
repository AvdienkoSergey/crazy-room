namespace ConsoleApp.CrazyRoom.Hero;

using ConsoleApp.CrazyRoom.Position;

public interface IHero
{
    char GetAvatar();
    
    /// <summary>
    /// Отрицательное движение по оси X
    /// </summary>
    /// <param name="min"> Значение, ниже которого игрок не может двигаться по оси X</param>
    void MoveLeft(sbyte min);
    
    /// <summary>
    /// Положительное движение по оси X
    /// </summary>
    /// <param name="max"> Значение, выше которого игрок не может двигаться по оси X</param>
    void MoveRight(sbyte max);
    
    /// <summary>
    /// Отрицательное движение по оси Y
    /// </summary>
    /// <param name="min"> Значение, ниже которого игрок не может двигаться по оси Y</param>
    void MoveUp(sbyte min);
    
    /// <summary>
    /// Положительное движение по оси Y
    /// </summary>
    /// <param name="max"> Значение, выше которого игрок не может двигаться по оси Y</param>
    void MoveDown(sbyte max);
    
    void SetPosition(IPosition position);
    
    IPosition GetPosition();

    int GetHealth();
}