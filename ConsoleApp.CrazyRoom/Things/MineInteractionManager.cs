namespace ConsoleApp.CrazyRoom.Things;

using Interfaces;

public class MineInteractionManager
{
    public void Subscribe(Mine? mine)
    {
        if (mine != null) mine.OnInteract += HandleInteraction;
    }
    
    private void HandleInteraction(ICharacter target)
    {
        if (target is Hero hero)
        {
            const int damageAmount = 10;
            hero.TakeDamage(damageAmount);
        }
    }
}