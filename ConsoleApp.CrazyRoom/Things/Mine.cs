namespace ConsoleApp.CrazyRoom.Things;

using Position;

public class Mine(char symbol, Position position, sbyte rangeOfAction)
    : Thing(symbol, position, rangeOfAction)
{
    public override void InteractWith(IGameCharacter? actor)
    {
        TriggerInteraction(actor);
    }
    
    public delegate void InteractionEventHandler(IGameCharacter actor);

    public event InteractionEventHandler? OnInteract;
    
    private void TriggerInteraction(IGameCharacter? actor)
    {
        if (actor != null) OnInteract?.Invoke(actor);
    }

    public override void TakeDamage(int value)
    {
        Console.WriteLine("Not Damaged");
    }
}