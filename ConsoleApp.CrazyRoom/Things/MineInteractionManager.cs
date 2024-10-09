namespace ConsoleApp.CrazyRoom.Things;

using Hero;

public class MineInteractionManager
{
    public void Subscribe(Mine? mine)
    {
        if (mine != null) mine.OnInteract += HandleInteraction;
    }
    
    private void HandleInteraction(IGameCharacter target)
    {
        if (target is Hero)
        {
            target.TakeDamage(1);
        }
    }
}