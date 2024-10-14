namespace ConsoleApp.CrazyRoom.Interfaces;

using Models.Things;

public interface IInteractionService
{
    void Subscribe(Thing? thing);
}