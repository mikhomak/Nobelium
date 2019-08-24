using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurtbox : MonoBehaviour, IHurtbox
{
    private ICharacter character;
    private HealthComponent healthComponent;
    [SerializeField] private bool activated = true;
    [SerializeField] private float damageMultiplier = 1;

    private void Start()
    {
        character = GetComponentInParent<ICharacter>();
        healthComponent = character.GetHealthComponent();
    }

    public void activate()
    {
        activated = true;
    }

    public void addToListeners()
    {
        GameManager.instance.addListenerToMainEvents(deactivate, activate);
    }

    public void deactivate()
    {
        activated = false;
    }

    public void takeDamage(float damage)
    {
        healthComponent.takeDamage(damage * damageMultiplier);
    }
}
