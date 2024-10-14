namespace ConsoleApp.CrazyRoom.Services;

using Models.Things;
using Interfaces;

public class RenderService : IRenderService
{
    public void Run(IRoom room)
    {
        ClearingScene();
    
        var roomWidth = room.GetWidth();
        var roomHeight = room.GetHeight();
        var hero = room.GetHero();
        var heroPosition = hero.GetPosition();
        var things = room.GetThingsListInRoom();

        for (var y = 0; y < roomHeight; y++)
        {
            for (var x = 0; x < roomWidth; x++)
            {
                if (heroPosition.X == x && heroPosition.Y == y)
                {
                    ShowHero(hero);
                }
                else if (things.Length == 0)
                {
                    ShowEmptyField();
                }
                else
                {
                    bool isEmpty = true;
                    foreach (var thing in things)
                    {
                        var thingPosition = thing.GetPosition();
                        if (thingPosition.X == x && thingPosition.Y == y)
                        {
                            isEmpty = false;
                            ShowThing(thing);
                            break;
                        }
                    }

                    if (isEmpty)
                    {
                        ShowEmptyField();
                    }
                }
            }
            Console.WriteLine();
        }
    }

    private void ClearingScene()
    {
        Console.Clear();
    }
    
    private void ShowHero(IHero hero)
    {
        Console.Write(hero.GetAvatar());
    }
    
    private void ShowEmptyField()
    {
        Console.Write('.');
    }
    
    private void ShowThing(Thing thing)
    {
        Console.Write(thing.GetAvatar());
    }
}