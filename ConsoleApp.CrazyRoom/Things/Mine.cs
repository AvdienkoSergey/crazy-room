namespace ConsoleApp.CrazyRoom.Things;

using Position;

public class Mine(char symbol, Position position, sbyte rangeOfAction)
    : Thing(symbol, position, rangeOfAction)
{
    // Правильно ли это делать здесь?
    // InteractionEventHandler является глобальным для всех экземпляров класса Thing
    // Я могу переместить его в абстрактный класс, но тогда плохая связанность дла экземпляра выйдет
    // Вдруг, будет появляться OnInteract?.Invoke(actor) и логику придется искать далеко
    public delegate void InteractionEventHandler(IGameCharacter actor);
    public event InteractionEventHandler? OnInteract;
    public override void InteractWith(IGameCharacter? actor)
    {
        TriggerInteraction(actor);
    }
    
    private void TriggerInteraction(IGameCharacter? actor)
    {
        if (actor != null) OnInteract?.Invoke(actor);
    }

    public override void TakeDamage(int value)
    {
        Console.WriteLine("Not Damaged");
    }
}