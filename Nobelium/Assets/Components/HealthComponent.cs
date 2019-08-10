
using UnityEngine;

public class HealthComponent : IComponent
{
    private float health = 100f;
    private bool activated = true;
    private ICharacter character;

    private void takeDamage(float health, float damage)
    {
        if (activated == false)
            return;
        health -= damage;
        if (health <= 0)
        {
            die();
        }
    }

    HealthComponent(ICharacter character) {
        this.character = character;
    }

    private void die()
    {
        character.die();
    }

    public void activate()
    {
        activated = true;
    }

    public void deactivate()
    {
        activated = false;
    }

    public void addToListeners()
    {
        GameManager.instance.addListenerToMainEvents(deactivate, activate);
    }
}
