namespace ConsoleApp.CrazyRoom.Services;

using Interfaces;
using Things;

public class MineInteractionService : IInteractionService
{
    public void Subscribe(Thing? thing)
    {
        if (thing != null) thing.OnInteract += HandleInteraction;
    }
    
    private void HandleInteraction(ICharacter target)
    {
        switch(target)
        {
            case Hero _:
            {
                target.TakeDamage(10);
                break;
            }
        }
    }
}