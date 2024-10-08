namespace ConsoleApp.CrazyRoom.Things;

using ConsoleApp.CrazyRoom.Position;
using ConsoleApp.CrazyRoom.Hero;

public abstract class Thing(char symbol, Position position)
{
    
    private readonly char _symbol = symbol;
    private readonly Position _position = position;
   
    /// <summary>
    /// Зона в которой сработает event InteractWithHero или InteractWithOtherThings 
    /// </summary>
    public abstract sbyte Zone { get; }
    
    /// <summary>
    /// Отображение предмета в игровой комнате
    /// </summary>
    /// <returns> Возвращает символ, которым будет обозначен предмет в игровой комнате </returns>
    public char GetAvatar()
    {
        return _symbol;
    }

    /// <summary>
    /// Находится ли что-то/кто-то в области взаимодействия с предметом
    /// </summary>
    /// <param name="someonePosition"> Проверяемая позиция </param>
    public bool IsSomeIsThingZone(Position someonePosition) 
    {
        return Math.Abs(someonePosition.X - _position.X) <= Zone && Math.Abs(someonePosition.Y - _position.Y) <= Zone;
    }
    
    /// <summary>
    /// Взаимодействие с героем
    /// </summary>
    public abstract void InteractWithHero(Hero hero);
    
    /// <summary>
    /// Взаимодействие с предметом
    /// </summary>
    /// <param name="someoneThing"> Какой-то предмет </param>
    public abstract void InteractWithOtherThings(Thing someoneThing);
}