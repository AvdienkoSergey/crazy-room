namespace ConsoleApp.CrazyRoom.Models.Things;

using ConsoleApp.CrazyRoom.Interfaces;

public class Mine(char symbol, IPosition position, sbyte rangeOfAction)
    : Thing(symbol, position, rangeOfAction)
{
    public override void InteractWith(ICharacter? actor)
    {
        TriggerInteraction(actor);
    }

    public override void TakeDamage(int value)
    {
        Console.WriteLine("Not Damaged");
    }
}