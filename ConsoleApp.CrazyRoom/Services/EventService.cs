namespace ConsoleApp.CrazyRoom.Services;

using Interfaces;

public class EventService : IEventService
{
    public void Run(IRoom room)
    {
        var hero = room.GetHero();
        var heroPosition = hero.GetPosition();
        var things = room.GetThingsListInRoom();

        foreach (var thing in things)
        {
            if (thing.InTheAreaOfAction(heroPosition))
            {
                Console.WriteLine("1");
                thing.InteractWith(hero as ICharacter);
            }
        }
    }
}